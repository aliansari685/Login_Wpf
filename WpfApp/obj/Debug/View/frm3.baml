   M S B A M L   `   `   `  ����
  WpfApp    WpfApp.Forms.Frm3   5   	   I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	     � SizeToContent$  WidthAndHeight=�5	       � WindowStartupLocation$ CenterScreen=�5
       � WindowStyle$
 None=�5       � AllowsTransparency .  � 
ResizeMode$ NoResize=�5      $��1q�6   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowEdges$	 All=�60      ShadowDepth$ Depth5=�6^      Darken . .��5      #  MaterialDesignThemes.Wpf.Card  -   5          Name$ window��5   	      MaterialDesignBody#���   5        PrimaryHueLightBrush#���  5   	   .��5   
   �� .  (MaterialDesignThemes.Wpf.ElevationAssist	   	Elevation$
	 Dp12=�6     MaterialDesignPaper#���  6C   $��Please Fill Information��6v   $	��340��6�   $��20,20,20,20q�6�   .��5      �� $	��300��6   .+�5      � 
 � ColumnDefinitions
 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   .+�5      �� -   5         ��Name$ Firstname_Box��5   K   
����  �$��40��61   $��13(�6=   $��1��6b   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  % !MaterialDesignFloatingHintTextBox#���  5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
First Name��6R   '  !MaterialDesignThemes.Wpf.PackIcon  5          Kind$
 User=�5!   *   $��0,20,5,0q�66   ��5    .   ��  �� ElementName$ Firstname_Box�� �� Path$ 
Foreground�5!   6   5"      � 5'      
 5(      �� 5)      $
��Auto �6+   �� 5*      $��* �6+   .+�5-      �� -   5        $ Lastname_Box��5-   K   
����  �$��13(�61   $��40��6?   $��1��6a    . #���  5.      $ 	Last Name��6R   $��0,5,0,0q�6}     5/      $ UserCardDetailsOutline=�50   *   $��0,23,5,0q�6H   ��5/   .   �� $ Lastname_Box��$ 
Foreground�50   H   51      � 56      
 57      �� 58      $
��Auto �6+   �� 59      $��* �6+   .+�5<      �� -   5        $ Username_Box��5<   \   
����  �$��0,5,0,0q�61   $��13(�6B   $��40��6P   $��1��6r    . #���  5=      $ UserName��6R     5>      $ 	UserCheck=�5?   *   $��0,23,5,0q�6;   ��5>   .   �� $ Username_Box��$ 
Foreground�5?   ;   5@      � 5E      
 5F      �� 5G      $
��Auto �6+   �� 5H      $��* �6+   .+�5K      �� -   5        $ Mail_Box��5K   \   
����  �$��0,5,0,0q�61   $��13(�6B   $��40��6P   $��1��6n    . #���  5L      $ E-Mail��6R     5M      $ Gmail=�5N   *   $��	0,23 ,5,0q�67   ��5M   .   �� $ Mail_Box��$ 
Foreground�5N   7   5O      � 5T      
 5U      �� 5V      $
��Auto �6+   �� 5W      $��* �6+   .+�5Z      G� -   5         G�Name$ Password_Box��5Z   `   
����  �$��0,5,0,0q�65   $��13(�6F   $��40��6T   $��1��6v    .  / +MaterialDesignFloatingHintRevealPasswordBox#���  5[      $ Password��6\     5\      $ Password=�5]   *   $��0,23,5,0q�6:   ��5\   .   �� $ Password_Box��$ 
Foreground�5]   :   5^      � 5c      
 5d      �� 5e      $
��Auto �6+   �� 5f      $��* �6+   .+�5i      G� -   5        $ Password_Box2��5i   `   
����  �$��0,5,0,0q�65   $��13(�6F   $��40��6T   $��1��6w    . #���  5j      $ Password Verified��6\     5k      $ PasswordVerified=�5l   *   $��0,23,5,0q�6B   ��5k   .   �� $ Password_Box2��$ 
Foreground�5l   B   5m      �� 5q      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�6   $��0,5,0,0q�6N   $��
BirthDay :��6_   .��5r      � 
 5s      �� 5t      $��* �6/   .+�5w      -  'HandyControl.Controls.PersianDatePicker  -   5          Name$ datepicker1��5w   /   $��16(�6D   $��Center=�6R      SelectedDateFormat$
 Long=�6v   6�   5x      5y      � 5~      
 5      �� 5�      $	��150 �6+   �� 5�      $
��Auto �6+   .+�5�      	� -	   5         	�Name$ 
read_radio��5�   "   $��Right=�66    d� 	IsChecked$
 TrueY�6R   $
��Read��6c   $��	0,10,10,0q�6r   	� 5�      -
   5        $ write_radio��5�   "   $��1��67   $��0,10,0,0q�6G   $��Write��6Y   {�.  6i   5�      �� 5�      -   5         ��Name$ RegisterBTN��5�       �� 	IsDefault .  " MaterialDesignFlatDarkBgButton#���  5�      $ Depth3=�5�      +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$ 5��5�      $��45��5�      $��	0,10,0,10q�5�      $��Create Account��5�      6*   �� 5�      -   5        $ Closing��5�       * &MaterialDesignFlatSecondaryLightButton#���  5�      $ Depth2=�5�      $ 5��5�      $��45��5�      $��4��5�      $��1��5�      $��Cancel��5�      6   5�      5�      5�      5�      