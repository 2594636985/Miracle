using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Miracle.Master.Intranet
{
    public class HttpRequest
    {
        public HttpListenerRequest HttpListenerRequest { private set; get; }

        public string ModuleName { private set; get; }

        public string ControllerName { private set; get; }

        public string ActionName { private set; get; }

        public Dictionary<string, string> Parameters { private set; get; }

        public HttpMethod HttpMethod { private set; get; }

        public long ContentLength { private set; get; }

        public string ContentType { private set; get; }

        public string ContentEncoding { private set; get; }

        public string Body { set; get; }

        public HttpRequest(HttpListenerRequest httpListenerRequest)
        {
            this.Parameters = new Dictionary<string, string>();
            this.HttpListenerRequest = httpListenerRequest;
            this.ContentEncoding = httpListenerRequest.ContentEncoding.BodyName;
            this.ContentLength = httpListenerRequest.ContentLength64;
            this.ContentType = httpListenerRequest.ContentType;
            this.HttpMethod = (HttpMethod)Enum.Parse(typeof(HttpMethod), httpListenerRequest.HttpMethod, true);
        }

        /// <summary>
        /// 初始化请求的数据信息
        /// </summary>
        public void InitializeHttpModule()
        {
            if (!string.IsNullOrWhiteSpace(this.HttpListenerRequest.RawUrl))
            {
                string mRawUrl = this.HttpListenerRequest.RawUrl;
                int questionIndex = this.HttpListenerRequest.RawUrl.IndexOf('?');

                if (questionIndex > 0)
                {
                    mRawUrl = mRawUrl.Substring(0, questionIndex);
                }

                string[] wildcards = mRawUrl.TrimStart('/').Split('/');

                if (wildcards != null && wildcards.Length >= 2)
                {
                    if (wildcards.Length > 2)
                    {
                        this.ModuleName = wildcards[0];
                        this.ControllerName = wildcards[1];
                        this.ActionName = wildcards[2];
                    }
                    else
                    {
                        this.ModuleName = "Default";
                        this.ControllerName = wildcards[0];
                        this.ActionName = wildcards[1];
                    }

                    if (this.HttpListenerRequest.QueryString.Count > 0)
                    {
                        foreach (string key in this.HttpListenerRequest.QueryString.Keys)
                        {
                            this.Parameters.Add(key, this.HttpListenerRequest.QueryString[key]);
                        }
                    }

                    if (this.HttpMethod == Intranet.HttpMethod.POST)
                    {
                        using (StreamReader sr = new StreamReader(this.HttpListenerRequest.InputStream, Encoding.UTF8))
                        {
                            this.Body = sr.ReadToEnd();
                            if (string.IsNullOrWhiteSpace(this.Body))
                            {
                                Dictionary<string, string> bodyParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(this.Body);
                                if (bodyParameters != null && this.HttpListenerRequest.QueryString.Count > 0)
                                {
                                    foreach (string key in bodyParameters.Keys)
                                    {
                                        this.Parameters.Add(key, bodyParameters[key]);
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
    }
}
