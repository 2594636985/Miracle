using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Miracle.Master.Intranet
{
    public class HttpResponse
    {
        public HttpListenerResponse HttpListenerResponse { private set; get; }

        public HttpStatusCode StatusCode { set; get; }

        public Encoding ContentEncoding { set; get; }

        public string ContentType { set; get; }

        public string Body { set; get; }

        public HttpResponse(HttpListenerResponse httpListenerResponse)
        {
            this.HttpListenerResponse = httpListenerResponse;
            this.ContentEncoding = Encoding.UTF8;
            this.ContentType = HttpContentTypes.ApplicationJson;
            this.StatusCode = HttpStatusCode.OK;
        }


        public void HandleHttpModuleResult()
        {
            this.HttpListenerResponse.ContentType = this.ContentType;
            this.HttpListenerResponse.ContentEncoding = this.ContentEncoding;
            this.HttpListenerResponse.StatusCode = (int)this.StatusCode;

            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                byte[] bodyBytes = Encoding.UTF8.GetBytes((this.Body));

                this.HttpListenerResponse.ContentLength64 = bodyBytes.Length;
                this.HttpListenerResponse.OutputStream.Write(bodyBytes, 0, bodyBytes.Length);
            }
            else
            {
                this.HttpListenerResponse.ContentLength64 = 0;
                this.HttpListenerResponse.OutputStream.Write(null, 0, 0);
            }

        }

    }
}
