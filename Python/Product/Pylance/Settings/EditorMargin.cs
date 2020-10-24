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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace Microsoft.PythonTools.Pylance.Settings {
    internal sealed class EditorMargin : IWpfTextViewMargin {
        private readonly ITextBuffer _tb;
        private readonly PropertyGrid _grid;
        private readonly ConfigProperties _properties;

        public EditorMargin(IWpfTextViewHost wpfTextViewHost, IWpfTextViewMargin marginContainer) {
            _tb = wpfTextViewHost.TextView.TextBuffer;
            _properties = new ConfigProperties();
            _grid = new PropertyGrid();
            _grid.SelectedObject = _properties;

            var host = new WindowsFormsHost();
            host.Child = _grid;
            VisualElement = host;
        }

        public FrameworkElement VisualElement { get; }

        public double MarginSize => 500;
        public bool Enabled => true;
        public void Dispose() {}
        public ITextViewMargin GetTextViewMargin(string marginName) => this;
    }
}
