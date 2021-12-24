using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpWebview;
using SharpWebview.Content;

namespace WebviewWrapper
{
    public class WebviewWrapper
    {
        private readonly Webview webview;
        private readonly bool _debugMode;
        private readonly bool _canRightClick;
        private readonly bool _canSelectText;
        private readonly string _defaultTitle;
        private readonly bool _destroyChildren;

        private int _height = 800;
        private int _width = 800;
        private string _title = "";
        private WebviewHint _frameHint = WebviewHint.None;

        private List<WebviewWrapper> children = new List<WebviewWrapper>();

        public WebviewWrapper(bool debugMode = false)
        {
            _debugMode = debugMode;
            _destroyChildren = true;
        }

        public WebviewWrapper CreateChild()
        {
            WebviewWrapper child = new WebviewWrapper();
            children.Add(child);

            return child;
        }

        private void Destroy()
        {
            webview.Dispose();
        }

        ~WebviewWrapper()
        {
            if (_destroyChildren)
            {
                foreach (WebviewWrapper webviewChild in children)
                {
                    webviewChild.Destroy();
                }
            }
            
            Destroy();
        }
    }
}
