﻿#pragma checksum "..\..\Pet_Details.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E110634B393ED3CE3C178059128C53C329BB99D959E654C2BE72B5DFDC87C41A"
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
using slnAdmin;


namespace slnAdmin {
    
    
    /// <summary>
    /// Pet_Details
    /// </summary>
    public partial class Pet_Details : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SelectName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadPicture;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imageDisp;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ID;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Naam;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Opmerking;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Geslacht;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Grootte;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Leeftijd;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Eigenaar;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Pet_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Type;
        
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
            System.Uri resourceLocater = new System.Uri("/slnAdmin;component/pet_details.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Pet_Details.xaml"
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
            this.SelectName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\Pet_Details.xaml"
            this.SelectName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectName_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UploadPicture = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Pet_Details.xaml"
            this.UploadPicture.Click += new System.Windows.RoutedEventHandler(this.UploadPicture_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.imageDisp = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.ID = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Naam = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Opmerking = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Geslacht = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Grootte = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.Leeftijd = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Eigenaar = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Type = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
