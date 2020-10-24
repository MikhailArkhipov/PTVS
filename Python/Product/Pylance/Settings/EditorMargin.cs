// Python Tools for Visual Studio
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Microsoft.PythonTools.Common.Infrastructure;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace Microsoft.PythonTools.Pylance.Settings {
    internal sealed class EditorMargin : Border, IWpfTextViewMargin {
        private readonly DisposableBag _disposables = new DisposableBag(nameof(EditorMargin));
        private readonly IWpfTextViewHost _wpfTextViewHost;
        private readonly ITextBuffer _tb;
        private readonly ConfigProperties _properties;
        private readonly WindowsFormsHost _host;

        private PropertyGrid _grid;

        public EditorMargin(IWpfTextViewHost wpfTextViewHost, IWpfTextViewMargin marginContainer) {
            _wpfTextViewHost = wpfTextViewHost;
            _tb = wpfTextViewHost.TextView.TextBuffer;
            _properties = new ConfigProperties();

            _host = new WindowsFormsHost() {
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
            };
            _host.Width = MarginSize;
            _grid = new PropertyGrid();
            _grid.Width = (int)MarginSize;

            _host.Child = _grid;
            Child = _host;

            _disposables.Add(_host).Add(_grid);
            _grid.SelectedObject = _properties;
        }

        #region IWpfTextViewMargin
        public FrameworkElement VisualElement => this;
        public double MarginSize => 400;
        public bool Enabled => true;
        public void Dispose() => _disposables.TryDispose();
        public ITextViewMargin GetTextViewMargin(string marginName) => this;
        #endregion
    }
}
