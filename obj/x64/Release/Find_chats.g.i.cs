﻿#pragma checksum "..\..\..\Find_chats.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7BDCFB017D185C82F0A38102CF78856060153B52380177DE94E67D56B53F084B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Find_messages_with_keywords;
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


namespace Find_messages_with_keywords {
    
    
    /// <summary>
    /// Find_chats
    /// </summary>
    public partial class Find_chats : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Find_chats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition Grid_Col_0;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Find_chats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition Grid_Row_0;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Find_chats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition Grid_Row_1;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Find_chats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Find_chats_background_text;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Find_chats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Find_chats_text;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Find_chats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer Scroll_viewer;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Find_chats.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Stack_chekboxes;
        
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
            System.Uri resourceLocater = new System.Uri("/Find messages with keywords;component/find_chats.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Find_chats.xaml"
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
            this.Grid_Col_0 = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 2:
            this.Grid_Row_0 = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 3:
            this.Grid_Row_1 = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.Find_chats_background_text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Find_chats_text = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\Find_chats.xaml"
            this.Find_chats_text.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Find_chats_text_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Scroll_viewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this.Stack_chekboxes = ((System.Windows.Controls.StackPanel)(target));
            
            #line 33 "..\..\..\Find_chats.xaml"
            this.Stack_chekboxes.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Stack_chekboxes_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

