﻿#pragma checksum "..\..\Menu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "691FAC5BA9C0A3144F9B735522B5FDD1CBF08FAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Fifa;
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


namespace Fifa {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddMatch;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btExit;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gContent;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddMatch_Copy;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddMatch_Copy1;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddMatch_Copy2;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddMatch_Copy3;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddMatch_Copy4;
        
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
            System.Uri resourceLocater = new System.Uri("/Fifa;component/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Menu.xaml"
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
            this.btAddMatch = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Menu.xaml"
            this.btAddMatch.Click += new System.Windows.RoutedEventHandler(this.ButtonAddMatch_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btExit = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Menu.xaml"
            this.btExit.Click += new System.Windows.RoutedEventHandler(this.ButtonExit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.gContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.btAddMatch_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Menu.xaml"
            this.btAddMatch_Copy.Click += new System.Windows.RoutedEventHandler(this.ButtonModifyMatch_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btAddMatch_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Menu.xaml"
            this.btAddMatch_Copy1.Click += new System.Windows.RoutedEventHandler(this.ButtonSearch_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btAddMatch_Copy2 = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\Menu.xaml"
            this.btAddMatch_Copy2.Click += new System.Windows.RoutedEventHandler(this.ButtonAddGoal_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btAddMatch_Copy3 = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Menu.xaml"
            this.btAddMatch_Copy3.Click += new System.Windows.RoutedEventHandler(this.ButtonDeleteMatch_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btAddMatch_Copy4 = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Menu.xaml"
            this.btAddMatch_Copy4.Click += new System.Windows.RoutedEventHandler(this.ButtonAddStadium_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

