   M S B A M L   `   `   `  ����V  RFind messages with keywords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Find_messages_with_keywordsFind_messages_with_keywords  5   	   ,    &Find_messages_with_keywords.Find_chats   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Find_messages_with_keywords     5   	     � Title$  Поиск чатов��5   	   $	��450��6   $	��300��6*    � 	Resources 5	         brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder   BooleanToVisibilityConverter  EntryFieldStyle �� 
TargetType �� Property �� Value��%  &	        &	      &	 =     &	 \     &	 o     �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   �� 5   
   6'   �� 5   
   " �6(   .�5      ��  � ��$ Stretch=�64   �� 5       � ��$ Center=�62   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ 
Grid_Col_0��5      $��1* �63   6@    � RowDefinitions 5   
   �� 5      -   5        	 ��Name$	 
Grid_Row_0��5      $
��0.1* �60   6@   �� 5      -   5        $	 
Grid_Row_1��5      $��* �60   6=   .+�5   
   �� -   5        
 ��Name$ 
 Find_chats_background_text��5      $��10q�68   $��0��6D   $��0��6Q   $��Center=�6a   $��Center=�6|   $C��=Ви можете найти канал по названию��6�   #��[ 6�   y�5      ��  �� ElementName$ Find_chats_text�� �� Path$ Text.IsEmpty� �� 	Converter# [ �� 5   
   -   5        $��Find_chats_text��5       �� TextWrapping$
 Wrap=�6)   $��0��6=   $��0��6J   
������ #��[ 6s   6�   �� 5    
   -   5         ��Name$ Scroll_viewer��5       $��0��6.   $��1��6>   .��5!      �� -   5         ��Name$ Stack_chekboxes��5!      62   5"      5#      5$      