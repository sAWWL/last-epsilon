﻿#pragma checksum "..\..\ChooseRecipe.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1DA6A24FC361F69BFD65197953E7907C76383D5B"
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
    /// ChooseRecipe
    /// </summary>
    public partial class ChooseRecipe : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\ChooseRecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView selectRecipe;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ChooseRecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadFile;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ChooseRecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newRecipeBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ChooseRecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteRecipeBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Project Epsilon;component/chooserecipe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChooseRecipe.xaml"
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
            this.selectRecipe = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.LoadFile = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\ChooseRecipe.xaml"
            this.LoadFile.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.newRecipeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\ChooseRecipe.xaml"
            this.newRecipeBtn.Click += new System.Windows.RoutedEventHandler(this.newRecipeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deleteRecipeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\ChooseRecipe.xaml"
            this.deleteRecipeBtn.Click += new System.Windows.RoutedEventHandler(this.deleteRecipeBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

