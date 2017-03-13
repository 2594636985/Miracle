
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Miracle.Master.Intranet
{
    using Modularization;
    using Registration;
    using System.IO;

    /// <summary>
    /// 通信器
    /// </summary>
    public class HttpServer
    {
        public HttpListener HttpListener { private set; get; }

        public event Action<HttpRequest, HttpResponse> OnRequested;

        public HttpServer(string prefix)
        {
            this.HttpListener = new HttpListener();
            this.HttpListener.Prefixes.Add(prefix);
        }

        public void ProcessRequest(HttpListenerContext context)
        {
            try
            {
                HttpRequest mRequest = new HttpRequest(context.Request);
                HttpResponse mResponse = new HttpResponse(context.Response);

                mRequest.InitializeHttpModule();

                if (this.OnRequested != null)
                    this.OnRequested(mRequest, mResponse);

                mResponse.HandleHttpModuleResult();

            }
            catch (Exception ex)
            {
                if (context.Response.StatusCode != (int)HttpStatusCode.Unauthorized)
                {
                    var responseBytes = Encoding.UTF8.GetBytes(ex.Message);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
                }

            }

        }

        public void Start()
        {
            //this.HttpListener.IgnoreWriteExceptions = true;
            //this.HttpListener.Start();

            //ThreadPool.QueueUserWorkItem((o) =>
            //{
            //    while (this.HttpListener != null && this.HttpListener.IsListening)
            //    {
            //        try
            //        {
            //            ThreadPool.QueueUserWorkItem((contextState) =>
            //            {
            //                var context = contextState as HttpListenerContext;
            //                this.ProcessRequest(context);

            //            }, this.HttpListener.GetContext());
            //        }
            //        catch
            //        {

            //        }
            //    }
            //}, this.HttpListener);
        }


        public void Stop()
        {
            if (this.HttpListener != null)
            {
                this.HttpListener.Stop();
                this.HttpListener.Close();
                this.HttpListener = null;
            }
        }
    }
}
