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

using System;
using System.ComponentModel.Composition;
using System.IO;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace Microsoft.PythonTools.Pylance.Settings {
    [Export(typeof(IWpfTextViewMarginProvider))]
    [Name("MsPythonConfigJsonPane")]
    [Order(After = PredefinedMarginNames.RightControl)]
    [MarginContainer(PredefinedMarginNames.Right)]
    [ContentType("JSON")]
    [TextViewRole(PredefinedTextViewRoles.Debuggable)] // This is to prevent the margin from loading in the diff view
    internal sealed class EditorMarginProvider : IWpfTextViewMarginProvider {
        public IWpfTextViewMargin CreateMargin(IWpfTextViewHost wpfTextViewHost, IWpfTextViewMargin marginContainer) {
            IWpfTextViewMargin margin = null;
            var tv = wpfTextViewHost.TextView;
            var filePath = tv.TextBuffer.GetFileName();
            if (!string.IsNullOrEmpty(filePath)) {
                var fileName = Path.GetFileName(filePath);
                if (string.Equals(fileName, "mspythonconfig.json", StringComparison.OrdinalIgnoreCase)) {
                    margin = tv.Properties.GetOrCreateSingletonProperty(()
                        => new EditorMargin(wpfTextViewHost, marginContainer));
                }
            }
            return margin;
        }
    }
}
