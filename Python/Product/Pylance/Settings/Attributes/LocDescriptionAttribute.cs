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
    /// Defines localizable description attribute. Description is a help string
    /// that is displayed in the editor Tools | Options page.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class LocDescriptionAttribute : DescriptionAttribute {
        private bool _replaced;

        #region Constructors
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="description">Attribute description.</param>
        public LocDescriptionAttribute(string description)
            : base(description) { }
        #endregion

        #region Overriden Implementation
        /// <summary>
        /// Gets attribute description.
        /// </summary>
        public override string Description {
            get {
                if (!_replaced) {
                    _replaced = true;
                    DescriptionValue = Strings.ResourceManager.GetString(base.Description);
                }

                return base.Description;
            }
        }
        #endregion
    }
}
