﻿#pragma checksum "..\..\AddServer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "583175503E9A90513B45A5EF390AA2FD38CE9737"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Project_Epsilon;
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
    /// AddServer
    /// </summary>
    public partial class AddServer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\AddServer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverName;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AddServer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverAddress;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AddServer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverPort;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddServer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox serverUsername;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddServer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddServerBtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AddServer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelAddBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Project Epsilon;component/addserver.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddServer.xaml"
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
            this.serverName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.serverAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.serverPort = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.serverUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddServerBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\AddServer.xaml"
            this.AddServerBtn.Click += new System.Windows.RoutedEventHandler(this.AddServerBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CancelAddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\AddServer.xaml"
            this.CancelAddBtn.Click += new System.Windows.RoutedEventHandler(this.CancelAddBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

