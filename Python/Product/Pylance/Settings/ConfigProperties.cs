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

using System.ComponentModel;
using Microsoft.PythonTools.Pylance.Settings.Attributes;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.PythonTools.Pylance.Settings {
    internal enum TypeCheckingMode {
        Off,
        Basic,
        Strict
    }

    internal sealed class ConfigProperties: DialogPage {
        [LocCategory(nameof(Strings.ConfigSettings_TypeCheckingCategory))]
        [CustomLocDisplayName(nameof(Strings.ConfigSettings_TypeCheckingMode))]
        [LocDescription(nameof(Strings.ConfigSettings_TypeCheckingMode_Description))]
        [TypeConverter(typeof(TypeCheckingModeTypeConverter))]
        [DefaultValue(TypeCheckingMode.Basic)]
        public TypeCheckingMode TypeCheckingMode { get; set; }

        [LocCategory(nameof(Strings.ConfigSettings_GeneralCategory))]
        [CustomLocDisplayName(nameof(Strings.ConfigSettings_UseLibraryCodeForTypes))]
        [LocDescription(nameof(Strings.ConfigSettings_UseLibraryCodeForTypes_Description))]
        [DefaultValue(true)]
        public TypeCheckingMode UseLibraryCodeForTypes { get; set; }

    }
}
