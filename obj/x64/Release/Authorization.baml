   M S B A M L   `   `   `  ���� V  RFind messages with keywords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Find_messages_with_keywordsFind_messages_with_keywords  /    )Find_messages_with_keywords.Authorization   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:Find_messages_with_keywords       � Title$  Авторизация��$	��370��$	��400�� � 	Resources    brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder   BooleanToVisibilityConverter  EntryFieldStyle �� 
TargetType �� Property �� Value��%�   &	        &	      &	 !     &	 2     &	 7     �� $ White���� $
 Gray���� $ Black���� �� " �.���  � ��$ Stretch=���  � ��$ Center=�.��� .+��� -    ��Name$' !TextBlock_phone_number_background��$
��7,10q�$	��250��$��25��$	��Top=�$
��Left=�$��Enter a phone number��#��[ y���  �� ElementName$ Phone_Number�� �� Path$ Text.IsEmpty�	 �� 	Converter#	 [ �� -   $��Phone_Number��$
��2,10q�$	��250��$��25��$	��Top=�$
��Left=�$y�Hidden=�$�� ��
������ #��[ �� -   $* $TextBlock_Auth_Phone_Code_background��$
��7,50q�$	��250��$��25��$	��Top=�$
��Left=�$1��+Enter a authentification code from telegram��#��[ y��� $ Auth_Phone_Code��$ Text.IsEmpty�#	 [ �� -   $��Auth_Phone_Code��$
��2,50q�$	��250��$��25��$	��Top=�$
��Left=�$y�Hidden=�$�� ��
������ #��[ �� -   $# TextBlock_Password_background��$
��7,90q�$	��250��$��25��$	��Top=�$
��Left=�$��Enter a password��#��[ y��� $ Password��$ Text.IsEmpty�#	 [ �� -   $��Password��$
��2,90q�$	��250��$��25��$	��Top=�$
��Left=�$y�Hidden=�$�� ��
������ #��[ .��
 J� Effect
 -  'System.Windows.Media.Effects.BlurEffect     Radius$ 7Q�.���� -   $( "TextBlock_Email_Address_background��$��7,130q�$	��250��$��25��$	��Top=�$
��Left=�$��Enter a email address��#��[ y��� $ Email_Address��$ Text.IsEmpty�#	 [ �� -   $��Email_Address��$��2,130q�$	��250��$��25��$	��Top=�$
��Left=�$y�Hidden=�$�� ��
������ #��[ �� -	   $* $TextBlock_Auth_Email_Code_background��$��7,170q�$	��250��$��25��$	��Top=�$
��Left=�$.��(Enter a authentification code from email��#��[ y��� $ Auth_Email_Code��$ Text.IsEmpty�#	 [ �� -
   $��Auth_Email_Code��$��2,170q�$	��250��$��25��$	��Top=�$
��Left=�$y�Hidden=�$�� ��
������ #��[ �� -   $��Phone_Number_label��$��Press Enter��$
��Left=�$��
257,10,0,0q�$	��Top=�
������ 
������ y��� $ Phone_Number��$ 	IsVisible�#	 [ �� -   $��Auth_Phone_Code_label��$��Press Enter��$
��Left=�$��
257,50,0,0q�$	��Top=�
������ 
������ y��� $ Auth_Phone_Code��$ 	IsVisible�#	 [ �� -   $��Password_label��$��Press Enter��$
��Left=�$��
257,90,0,0q�$	��Top=�
������ 
������ y��� $ Password��$ 	IsVisible�#	 [ �� -   $��Email_Address_label��$��Press Enter��$
��Left=�$��257,130,0,0q�$	��Top=�
������ 
������ y��� $ Email_Address��$ 	IsVisible�#	 [ �� -   $��Auth_Email_Code_label��$��Press Enter��$
��Left=�$��257,170,0,0q�$	��Top=�
������ 
������ y��� $ Auth_Email_Code��$ 	IsVisible�#	 [ 