   M S B A M L   `   `   `  ���� V  RFind messages with keywords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Find_messages_with_keywordsFind_messages_with_keywords  ,    &Find_messages_with_keywords.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:Find_messages_with_keywords     -     � Title$'  !Пошук повідомлень��$	��250��$	��750�� � 	Resources    brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder   BooleanToVisibilityConverter  EntryFieldStyle �� 
TargetType �� Property �� Value��%�   &	        &	      &	 !     &	 2     &	 7     �� $ White���� $
 Gray���� $ Black���� �� " �.���  � ��$ Stretch=���  � ��$ Center=�.���  � RowDefinitions �� -    ��Name$ 
Grid_Row_0��$
��Auto ��� -   $ 
Grid_Row_1��$��* �.+�o� 
�������$
��Left=�$	��Top=�$��Tahoma)�$��14(�$��0������ *Height+ �� ElementName$ 
Grid_Row_0��	 �� Mode$	 OneWay=�.@�m� -   
 m�Name$
 Menu_autorize��
�������$"��Авторизуватись��
�������$��2q� � Cursor$
 Hand��m� -   $
 Menu_change_chat_links��
�������$1��+Змінити чати для пошуку��
�������$��2q�$
 Hand��m� -   $
 Menu_keywords��
�������$3��-Змінити слова для пошуку��
�������$��2q�$
 Hand���� -   $��TextBox_time��$��75��$	��Top=�$
��Left=� � ToolTip$� �Вкажіть за скільки годин тому надіслані повідомлення треба знаходити��
������ #��[ �� -    ��Name$
 Stop��$
��Stop��$��50��$��Tahoma)�$��14(�{�.  �� -	   $ Start��$��Start��$��50��$��Tahoma)�$��14(�� $��1��.+��� -
    ��Name$ Scroll_viewer��$��Disabled=�$��Stretch=�$��Stretch=����� *Height+$ 
Grid_Row_2��$	 OneWay=����� .R���  �� Orientation$ Vertical=�.+��� $��10q�$��Times New Roman)�$��14(�$
��Wrap=����� *Text+�� ���� *Url+.�.��� ��� *
LinkText+