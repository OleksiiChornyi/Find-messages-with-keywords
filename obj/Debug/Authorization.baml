   M S B A M L   `   `   `  ����V  RFind messages with keywords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Find_messages_with_keywordsFind_messages_with_keywords  5   	   /    )Find_messages_with_keywords.Authorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:Find_messages_with_keywords     5   	     � Title$  Authorization��5   	   $	��450��6   $	��800��6,    � 	Resources 5	         brushWatermarkBackground �� Color  brushWatermarkForeground  brushWatermarkBorder   BooleanToVisibilityConverter  EntryFieldStyle �� 
TargetType �� Property �� Value��%  &	        &	      &	 =     &	 \     &	 o     �� 5   
   $ White��6;   �� 5   
   $
 Gray��6;   �� 5   
   $ Black��67   �� 5   
   6'   �� 5   
   " �6(   .�5      ��  � ��$ Stretch=�64   �� 5       � ��$ Center=�62   5      5      .��5      � .+�5   
   �� -   5         ��Name$' !TextBlock_phone_number_background��5      $
��7,10q�6@   $	��250��6N   $��25��6Z   $	��Top=�6f   $
��Left=�6~   $��Enter a phone number��6�   #��[ 6�   y�5      ��  �� ElementName$ Phone_Number�� �� Path$ Text.IsEmpty�	 �� 	Converter#	 [ �� 5   
   -   5        $��Phone_Number��5      $
��2,10q�6&   $	��250��64   $��25��6@   $	��Top=�6L   $
��Left=�6d   $y�Hidden=�6   $�� ��6�   
������ #��[ 6�   6  �� 5   
   -   5        $* $TextBlock_Auth_Phone_Code_background��5      $
��7,50q�6B   $	��250��6P   $��25��6\   $	��Top=�6h   $
��Left=�6�   $1��+Enter a authentification code from telegram��6�   #��[ 6�   y�5      �� $ Auth_Phone_Code��$ Text.IsEmpty�#	 [ �� 5   
   -   5        $��Auth_Phone_Code��5      $
��2,50q�6)   $	��250��67   $��25��6C   $	��Top=�6O   $
��Left=�6g   $y�Hidden=�6�   $�� ��6�   
������ #��[ 6�   6�   �� 5   
   -   5        $# TextBlock_Password_background��5      $
��7,90q�6;   $	��250��6I   $��25��6U   $	��Top=�6a   $
��Left=�6y   $��Enter a password��6�   #��[ 6�   y�5      �� $ Password��$ Text.IsEmpty�#	 [ �� 5   
   -   5        $��Password��5      $
��2,90q�6"   $	��250��60   $��25��6<   $	��Top=�6H   $
��Left=�6`   $y�Hidden=�6{   $�� ��6�   
������ #��[ 6�   .��6C  
 J� Effect
 5      -  'System.Windows.Media.Effects.BlurEffect  5          Radius$ 7Q�6   .��5!      5"      �� 5#   
   -   5        $( "TextBlock_Email_Address_background��5#      $��7,130q�6@   $	��250��6O   $��25��6[   $	��Top=�6g   $
��Left=�6   $��Enter a email address��6�   #��[ 6�   y�5$      �� $ Email_Address��$ Text.IsEmpty�#	 [ �� 5%   
   -   5        $��Email_Address��5%      $��2,130q�6'   $	��250��66   $��25��6B   $	��Top=�6N   $
��Left=�6f   $y�Hidden=�6�   $�� ��6�   
������ #��[ 6�   6  �� 5&   
   -	   5        $* $TextBlock_Auth_Email_Code_background��5&      $��7,170q�6B   $	��250��6Q   $��25��6]   $	��Top=�6i   $
��Left=�6�   $.��(Enter a authentification code from email��6�   #��[ 6�   y�5'      �� $ Auth_Email_Code��$ Text.IsEmpty�#	 [ �� 5(   
   -
   5        $��Auth_Email_Code��5(      $��2,170q�6)   $	��250��68   $��25��6D   $	��Top=�6P   $
��Left=�6h   $y�Hidden=�6�   $�� ��6�   
������ #��[ 6�   6�   �� 5)   
   -   5        $��Phone_Number_label��5)      $��Press Enter��6*   $
��Left=�6@   $��
257,10,0,0q�6[   $	��Top=�6o   
������ 
������ y�6�   �� $ Phone_Number��$ 	IsVisible�#	 [ 6  �� 5*   
   -   5        $��Auth_Phone_Code_label��5*      $��Press Enter��6-   $
��Left=�6C   $��
257,50,0,0q�6^   $	��Top=�6r   
������ 
������ y�6�   �� $ Auth_Phone_Code��$ 	IsVisible�#	 [ 6  �� 5+   
   -   5        $��Password_label��5+      $��Press Enter��6&   $
��Left=�6<   $��
257,90,0,0q�6W   $	��Top=�6k   
������ 
������ y�6�   �� $ Password��$ 	IsVisible�#	 [ 6  �� 5,   
   -   5        $��Email_Address_label��5,      $��Press Enter��6+   $
��Left=�6A   $��257,130,0,0q�6\   $	��Top=�6q   
������ 
������ y�6�   �� $ Email_Address��$ 	IsVisible�#	 [ 6  �� 5-   
   -   5        $��Auth_Email_Code_label��5-      $��Press Enter��6-   $
��Left=�6C   $��257,170,0,0q�6^   $	��Top=�6s   
������ 
������ y�6�   �� $ Auth_Email_Code��$ 	IsVisible�#	 [ 6   5.      5/      