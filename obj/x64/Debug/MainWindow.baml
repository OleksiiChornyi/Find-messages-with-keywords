   M S B A M L   `   `   `  ����V  RFind messages with keywords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Find_messages_with_keywordsFind_messages_with_keywords  5   	   ,    &Find_messages_with_keywords.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Find_messages_with_keywords     5   	   -   5          � Title$#  Поиск сообщений��5   	   $	��250��6!   $	��750��6.    � 	Resources 5	         brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder   BooleanToVisibilityConverter  EntryFieldStyle �� 
TargetType �� Property �� Value��%  &	        &	      &	 =     &	 \     &	 o     �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   �� 5   
   6'   �� 5   
   " �6(   .�5      ��  � ��$ Stretch=�64   �� 5       � ��$ Center=�62   5      5      .��5      �  � RowDefinitions 5   
   �� 5      -   5         ��Name$ 
Grid_Row_0��5      $
��Auto �60   �� 5      -   5        $ 
Grid_Row_1��5      $��* �60   .+�5   
   o� 
�������$
��Left=�6"   $	��Top=�6=   $��Tahoma)�6U   $��14(�6i   $��0��6w   ��6�   �� *Height+ �� ElementName$ 
Grid_Row_0��	 �� Mode$	 OneWay=�.@�5      m� -   5        
 m�Name$
 Menu_autorize��5      
�������$&�� Авторизироваться��6A   
�������$��2q�6s    � Cursor$
 Hand��6�   6�   m� 5      -   5        $
 Menu_change_chat_links��5      
�������$&�� Каналы для поиска��6J   
�������$��2q�6}   $
 Hand��6�   6�   m� 5      -   5        $
 Menu_keywords��5      
�������$$��Слова для поиска��6A   
�������$��2q�6s   $
 Hand��6�   6�   m� 5      -   5        $
 Menu_about_program��5      
�������$��О программе��6F   
�������$��2q�6s   $
 Hand��6�   6�   �� 5      -   5        $��TextBox_time��5      $��75��6*   $	��Top=�65   $
��Left=�6M    � ToolTip$� {Укажите сколько часов назад отправленные сообщения нужно находить��6h   
������ #��[ 6�   6   �� 5       -	   5         ��Name$
 Stop��5       $��Стоп��6#   $��50��62   $��Tahoma)�6=   $��14(�6Q   {�.  6�   �� 5!      -
   5        $ Start��5!      $��
Старт��6$   $��50��64   $��Tahoma)�6?   $��14(�6S   6w   5"      � 5#   
   $��1��6   .+�5$      �� -   5         ��Name$ Scroll_viewer��5$      $��Disabled=�6.   $��Stretch=�6d   $��Stretch=�6�   ��6�   �� *Height+$ 
Grid_Row_2��$	 OneWay=���5%      �� 5&      .R�5'      ��  �� Orientation$ Vertical=�6%   .+�5(      �� $��10q�6>   $��Times New Roman)�6J   $��14(�6g   $
��Wrap=�6u   ��6(   �� *Text+�� 5)   "   ��6,   �� *Url+.�6H   .�5*   &   �� �6*   �� *
LinkText+5+   #   5,      5-      5.      50      51      52      53      