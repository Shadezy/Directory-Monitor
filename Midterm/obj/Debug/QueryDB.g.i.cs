﻿#pragma checksum "..\..\QueryDB.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "69996BCD5103A3FA864F68BB01CAD4A74E7CE313AEDFCF43A70F225E5B58D9C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Midterm;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Midterm {
    
    
    /// <summary>
    /// QueryDB
    /// </summary>
    public partial class QueryDB : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_db;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_db;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_db_err;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_extensions;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_extensions;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_extensions;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_current;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_go;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_delete;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_content;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\QueryDB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_delete;
        
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
            System.Uri resourceLocater = new System.Uri("/Midterm;component/querydb.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\QueryDB.xaml"
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
            this.lbl_db = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.btn_db = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\QueryDB.xaml"
            this.btn_db.Click += new System.Windows.RoutedEventHandler(this.Btn_db_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbl_db_err = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lbl_extensions = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txt_extensions = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_extensions = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\QueryDB.xaml"
            this.btn_extensions.Click += new System.Windows.RoutedEventHandler(this.Btn_extensions_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lbl_current = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.btn_go = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\QueryDB.xaml"
            this.btn_go.Click += new System.Windows.RoutedEventHandler(this.Btn_go_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_delete = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\QueryDB.xaml"
            this.btn_delete.Click += new System.Windows.RoutedEventHandler(this.Btn_delete_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dg_content = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.lbl_delete = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

