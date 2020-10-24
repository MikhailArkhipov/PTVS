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
using System.ComponentModel;

namespace Microsoft.PythonTools.Pylance.Settings.Attributes {
    /// <summary>
    /// Defines a localizable name attribute. The name is visible in the editor Tools | Options page.
    /// The class LocDisplayNameAttribute doesn't seem to be able to load our strings, so this new class is needed.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class CustomLocDisplayNameAttribute : DisplayNameAttribute {
        private bool _replaced;

        public CustomLocDisplayNameAttribute(string name)
            : base(name) { }

        public override string DisplayName {
            get {
                if (!_replaced) {
                    _replaced = true;
                    DisplayNameValue = Strings.ResourceManager.GetString(DisplayNameValue);
                }

                return base.DisplayName;
            }
        }
    }
}
