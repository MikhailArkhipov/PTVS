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
    /// Defines localizable category attribute. Category is visible in the editor Tools | Options page.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class LocCategoryAttribute : CategoryAttribute {
        #region Constructors
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="description">Category name.</param>
        public LocCategoryAttribute(string category)
            : base(category) { }
        #endregion

        #region Overriden Implementation
        /// <summary>
        /// Gets localized category name.
        /// </summary>
        protected override string GetLocalizedString(string value)
            => Strings.ResourceManager.GetString(Category);
        #endregion
    }
}
