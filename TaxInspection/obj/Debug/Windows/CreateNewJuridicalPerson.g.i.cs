﻿#pragma checksum "..\..\..\Windows\CreateNewJuridicalPerson.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5C757363B9F83B1C4286F39903AE1F7A799EA5D969811AC49683776BC893AA68"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TaxInspection.Windows;


namespace TaxInspection.Windows {
    
    
    /// <summary>
    /// CreateNewJuridicalPerson
    /// </summary>
    public partial class CreateNewJuridicalPerson : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Name_label;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DateOfRegistration_label;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Code_label;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Code;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewPersonButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaxInspection;component/windows/createnewjuridicalperson.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Name_label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.DateOfRegistration_label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Code_label = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Code = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
            this.Code.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckCodeInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddNewPersonButton = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Windows\CreateNewJuridicalPerson.xaml"
            this.AddNewPersonButton.Click += new System.Windows.RoutedEventHandler(this.AddNewPerson);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Date = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

