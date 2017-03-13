using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Miracle.Master
{
    using Modularization;
    using Intranet;
    using Registration;
    using Newtonsoft.Json;
    using Desktop;

    public partial class MiracleMaster
    {
        public MiracleXml MiracleXml { private set; get; }

        public ModuleFramework ModuleFramework { private set; get; }

        public HttpServer HttpServer { private set; get; }

        public RegisterCenter RegisterCenter { private set; get; }

        public IViewPageLoader ViewPageLoader { private set; get; }

        public string AppLocation { private set; get; }

        public event Action<MiracleMaster> OnInitialized;




        #region 私有方法

        /// <summary>
        /// 获得模块内核需要的信息
        /// </summary>
        /// <returns></returns>
        private ModuleSetupInformation GetModuleSetupInformation()
        {
            ModuleSetupInformation moduleSetupInformation = new ModuleSetupInformation();
            moduleSetupInformation.AddInName = this.MiracleXml.AddInName;
            moduleSetupInformation.AppLocation = this.AppLocation;
            moduleSetupInformation.ConnectionString = this.MiracleXml.ConnectionString;
            moduleSetupInformation.StartModuleName = this.MiracleXml.StartModuleName;

            return moduleSetupInformation;
        }

        /// <summary>
        /// 获得配置相关的信息
        /// </summary>
        /// <returns></returns>
        private MiracleXml GetMiracleXml()
        {
            MiracleXml mXml = new MiracleXml(Path.Combine(this.AppLocation, "Miracle.Xml"));

            mXml.Initialize();

            return mXml;
        }

        /// <summary>
        /// 处理相应的请求处理
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        private void HttpServer_OnRequested(HttpRequest request, HttpResponse response)
        {
            string moduleName = request.ModuleName;
            string controllerName = request.ControllerName;
            string actionName = request.ActionName;
            Dictionary<string, string> parameters = request.Parameters;


            ActionInvocation actionInvocation = this.ModuleFramework.NewActionInvocation(moduleName);

            if (actionInvocation != null)
            {
                actionInvocation.Setup(controllerName, actionName, parameters);
                response.Body = JsonConvert.SerializeObject(actionInvocation.Invoke());
            }
            else
            {
                response.Body = "系统里面找不到定义的{0}Action方法".FormatEx(actionName);
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
            }

        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            this.AppLocation = AppDomain.CurrentDomain.BaseDirectory;

            this.MiracleXml = this.GetMiracleXml();

            this.ModuleFramework = new ModuleFramework(this.GetModuleSetupInformation());
            this.ModuleFramework.SetupExtensional();
            this.ModuleFramework.Activate();

            this.RegisterCenter = new RegisterCenter(this);
            this.RegisterCenter.RegisterLocalList();
            this.RegisterCenter.RegisterMachine(this.ModuleFramework);


            this.HttpServer = new HttpServer(this.MiracleXml.HttpServerUrl);
            this.HttpServer.OnRequested += HttpServer_OnRequested;

            if (this.OnInitialized != null)
                this.OnInitialized(this);

        }


        public void SteupViewPageLoader(IViewPageLoader viewPageLoader)
        {
            this.ViewPageLoader = viewPageLoader;
        }


        public void Start()
        {
            this.HttpServer.Start();
        }

        public void Stop()
        {
            this.HttpServer.Stop();
        }

        public bool CheckLatestVersion()
        {
            return true;
        }

        public IWindowShell GetAppWindowShell()
        {
            IModule module = this.ModuleFramework.GetModule(this.MiracleXml.StartModuleName);

            if (module == null)
                throw new ArgumentNullException("没有找到相关的启动模块");

            return module.GetWindowShell();
        }

        #endregion

    }
}
