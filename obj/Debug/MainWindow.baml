   M S B A M L   `   `   `  ����V  RFind messages with keywords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Find_messages_with_keywordsFind_messages_with_keywords  5   	   ,    &Find_messages_with_keywords.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Find_messages_with_keywords     5   	     � Title$'  !Пошук повідомлень��5   	   $	��250��6#   $	��675��60    � 	Resources 5	         brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder   BooleanToVisibilityConverter  EntryFieldStyle �� 
TargetType �� Property �� Value��%  &	        &	      &	 =     &	 \     &	 o     �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   �� 5   
   6'   �� 5   
   " �6(   .�5      ��  � ��$ Stretch=�64   �� 5       � ��$ Center=�62   5      5      .��5      �  � RowDefinitions 5   
   �� 5      -   5         ��Name$ 
Grid_Row_0��5      $
��Auto �60   �� 5      -   5        $ 
Grid_Row_1��5      $��* �60   .+�5   
   o� 
�������$
��Left=�6"   $	��Top=�6=   $��Tahoma)�6U   $��14(�6i   $��0��6w   ��6�   �� *Height+ �� ElementName$ 
Grid_Row_0��	 �� Mode$	 OneWay=�.@�5      m� -   5        
 m�Name$
 Menu_autorize��5      
�������$"��Авторизуватись��6A   
�������$��2q�6q    � Cursor$
 Hand��6�   6�   m� 5      -   5        $
 Menu_change_chat_links��5      
�������$1��+Змінити чати для пошуку��6J   
�������$��2q�6�   $
 Hand��6�   m� 5      -   5        $
 Menu_keywords��5      
�������$3��-Змінити слова для пошуку��6A   
�������$��2q�6{   $
 Hand��6�   �� 5      -   5        $��TextBox_time��5      $	��100��6*   $	��Top=�66   $
��Left=�6N   
������ #��[ 6�   �� 5      -   5         ��Name$ Start��5      $��Start��6$   $��50��64   $��Tahoma)�6?   $��14(�6S   6c   5       � 5!   
   $��1��6   .+�5"      �� -   5         ��Name$ Scroll_viewer��5"      $	��Top=�62   $
��Auto=�6�   $��0��6�   ��6J   �� *Height+$ 
Grid_Row_1��$	 OneWay=�.��5#      �� -	   5         ��Name$ TextBlock_result��5#      $��10q�66   $��Times New Roman)�6B   $��14(�6_   $
��Wrap=�6m   6�   5$      5%      5&      5'      