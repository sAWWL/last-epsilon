﻿#pragma checksum "..\..\ToolSetupWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "188C49C3F7291B622F985FF756306C751718DBDF"
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


namespace Project_Epsilon {
    
    
    /// <summary>
    /// ToolSetupWindow
    /// </summary>
    public partial class ToolSetupWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\ToolSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ToolConfCheckBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ToolSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ToolUDILabel;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ToolSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ToolUDITextbox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ToolSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NumCavsLabel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ToolSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumCavsTextbox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ToolSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ToolSetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/Project Epsilon;component/toolsetupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ToolSetupWindow.xaml"
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
            this.ToolConfCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 15 "..\..\ToolSetupWindow.xaml"
            this.ToolConfCheckBox.Click += new System.Windows.RoutedEventHandler(this.ToolConfChecked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ToolUDILabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ToolUDITextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\ToolSetupWindow.xaml"
            this.ToolUDITextbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ToolUDITextbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NumCavsLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.NumCavsTextbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\ToolSetupWindow.xaml"
            this.NumCavsTextbox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 19 "..\..\ToolSetupWindow.xaml"
            this.NumCavsTextbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NumCavsTextbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BackButton2 = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\ToolSetupWindow.xaml"
            this.BackButton2.Click += new System.Windows.RoutedEventHandler(this.BackButton);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ErrorMessage = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

