using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace Server
{
    class ModifiedHttpListener
    {
        private readonly string _url;
        private bool _isListening = false;
        private readonly HttpListener _listener = new HttpListener();
        private HttpListenerContext _context;
        private HttpListenerRequest _request;
        private HttpListenerResponse _response;
        private Thread _backgroungThread;
        
        public ModifiedHttpListener(Uri uri)
        {
            _url = uri.AbsoluteUri;        
        }    

        public void StartListen()
        {
            _backgroungThread = new Thread(new ThreadStart(Start));
            _backgroungThread.IsBackground = true;
            _backgroungThread.Name = "MyHttpListener";
            _backgroungThread.Start();
        }

        private void Start()
        {
            _listener.Prefixes.Add(_url);
            _listener.Start();

            _isListening = true;
            
            while (_isListening)
            {
                _context = _listener.GetContext();
                _request = _context.Request;
                _response = _context.Response;
                var outputString = string.Empty;
                try
                {
                    var dir = new DirectoryInfo(_request.RawUrl.Remove(0, 1));
                    if (dir.Exists)
                    {
                        var fileSystemInfos = dir.EnumerateFileSystemInfos();

                        outputString = JsonConvert.SerializeObject(fileSystemInfos);
                        var buffer = Encoding.Default.GetBytes(outputString);
                        _response.ContentLength64 = buffer.Length;
                        using (var output = _response.OutputStream) { output.Write(buffer, 0, buffer.Length); }

                        
                    }
                    else
                    {
                        outputString = JsonConvert.SerializeObject("There is no such directory");
                        var buffer = Encoding.Default.GetBytes(outputString);
                        _response.ContentLength64 = buffer.Length;
                        using (var output = _response.OutputStream) { output.Write(buffer, 0, buffer.Length); }
                    }
                }
                catch (Exception ex)
                {
                    outputString = JsonConvert.SerializeObject(ex.Message);
                    var buffer = Encoding.Default.GetBytes(outputString);
                    _response.ContentLength64 = buffer.Length;
                    using (var output = _response.OutputStream) { output.Write(buffer, 0, buffer.Length); }
                }
            }
        }
        
        public void StopListen()
        {
            _isListening = false;
            _listener.Stop();
            _listener.Close();
        }
    }
}
