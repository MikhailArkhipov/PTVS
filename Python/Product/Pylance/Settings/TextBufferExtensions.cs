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

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Projection;

namespace Microsoft.PythonTools.Pylance.Settings {
    internal static class TextBufferExtensions {
        /// <summary>
        /// Retrieves full path to the file opened in the text buffer.
        /// Not all text buffers have files associated with them,
        /// </summary>
        public static string GetFileName(this ITextBuffer textBuffer) {
            var path = string.Empty;
            var document = textBuffer.GetTextDocument();
            if (document?.FilePath != null) {
                path = document.FilePath;
            }
            return path;
        }

        public static ITextDocument GetTextDocument(this ITextBuffer textBuffer) {
            var searchBuffers = textBuffer.GetContributingBuffers();
            return searchBuffers
                .Select(buffer => {
                    buffer.Properties.TryGetProperty(typeof(ITextDocument), out ITextDocument document);
                    return document;
                })
                .FirstOrDefault(d => d != null);
        }

        public static IEnumerable<ITextBuffer> GetContributingBuffers(this ITextBuffer textBuffer) {
            var allBuffers = new List<ITextBuffer> { textBuffer };

            for (var i = 0; i < allBuffers.Count; i++) {
                if (allBuffers[i] is IProjectionBuffer currentBuffer) {
                    foreach (var sourceBuffer in currentBuffer.SourceBuffers) {
                        if (!allBuffers.Contains(sourceBuffer)) {
                            allBuffers.Add(sourceBuffer);
                        }
                    }
                }
            }
            return allBuffers;
        }

    }
}
