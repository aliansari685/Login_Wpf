   M S B A M L   `   `   `  ����
  WpfApp    WpfApp.Forms.Frm2   5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   I EWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=null^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � SizeToContent$  Manual=�5   	    � WindowStartupLocation$ CenterScreen=�5	       � WindowState$ 	Maximized=�5
   	    � WindowStyle$ SingleBorderWindow=�5       � Title$
 Main��5   	   $
��1200��6   .��5      #  MaterialDesignThemes.Wpf.Card  -   5          Name$ window��5   	      MaterialDesignBody#���   5        MaterialDesignPaper#���  5      .��5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��250 �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	DataView1��5        PrimaryHueDarkBrush   HorizontalGridLinesBrush# �  5        PrimaryHueLightBrush#���  6X   
���   �	   MaxColumnWidth$		 230Q�5   *   
   
IsReadOnly
 .    HeadersVisibility$	 All=�5   )   $��14(�6A      GridLinesVisibility$	 All=�6O   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5    E      RowStyle 5!      �� 5"       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5#      P� 5$       P� Property �@ 
IsSelected P� Value . . �5%   "   ��  �� Property � ��   MaterialDesignDarkForeground �� Value# �  6?   �� 5&   "    � ��  PrimaryHueMidBrush# �  6?   �� 5'   "    � ��$ SemiBold"�6?   5(      5*      5,      �� 50      $��0q�6   $��1��6#   .��51      �  � RowDefinitions 52      �� 53      $
��Auto �6(   �� 54      $��* �6(   �� 55      $
��Auto �6(   �� 56      $��* �6(   .+�5:      �� $��Information��6   .��5;      � $��Center=�6   $��Center=�6:    5<      �� 5=   "   $
��Auto �63   �� 5>   "   $
��Auto �63   .+�5A      �� $��0��6)   .+�5B   "   �� $��70��6)   $��
Username :��64   �� 5C   "   $��70��6)   $��Time :��64   5D      �� 5E      $��1��6)   .+�5F   "   �� -   5         ��Name$ lbl_username��5F   3   $�� ��6(   63   �� 5G   "   -   5        $ lbl_time��5G   4   $�� ��6(   64   5H      5I      5J      �� 5M      $��1��6   $��Search��6,   .��5N      � $��Center=�6    .+�5O      �� $��Center=�6)   .+�5P   "   �� -   5        $��	searchbox��5P   6   $	��200��6*    ! MaterialDesignOutlinedTextBox#���  6G   .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextFieldCornerRadius$ 5��6      HasClearButton . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ All Column...��5Q   [   $��50��6�   6�   �� 5R   "   -   5         ��Name$ 
btn_Search��5R   :    �� 	IsDefault .  # MaterialDesignRaisedLightButton#���  6N   $��Seach��6�   $��0 10 0 0q�6�   $��44��6�   6�   5S      5T      5U      �� 5X      $��2��6   $��Column Visible��6,   .��5Y      � $��Stretch=�6   $��Stretch=�6;    5Z      �� 5[   "   $��* �63   �� 5\   "   $��* �63   �� 5]   "   $��* �63   .+�5a      �� $��0��6)   .+�5b   "   �� -   5         ��Name$ checkBox_Row��5b   D   
 � Tag$ 1��6+   $��0,0,0,3q�63   $	��Row��6Z    d� 	IsChecked$
 TrueY�6�   �� 5c   "   -	   5        $ checkBox_First��5c   D   $ 2��6+   $��0,0,0,3q�63   $��	Firstname��6\   $
 TrueY�6�   �� 5d   "   -
   5        $ checkBox_Last��5d   3   $ 3��6+   $��Lastname��6J   $
 TrueY�6^   6o   5e      �� 5h      $��1��6)   .+�5i   "   �� -   5        $ checkBox_User��5i   D   $ 4��6+   $��0,0,0,3q�63   $��Username��6[   $
 TrueY�6�   �� 5j   "   -   5        $ checkBox_Mail��5j   D   $ 5��6+   $��0,0,0,3q�63   $
��Mail��6[   $
 TrueY�6�   �� 5k   "   -   5        $ checkBox_Pass��5k   3   $ 6��6+   $��Password��6J   $
 TrueY�6x   5l      �� 5o      $��2��6)   .+�5p   "   �� -   5        $ checkBox_Modify��5p   D   $ 7��6+   $��0,0,0,3q�63   $��Modify��6]   $
 TrueY�6�   �� 5q   "   -   5        $ checkBox_RegisterDate��5q   D   $ 8��6+   $��0,0,0,3q�63   $��RegDate��6c   $
 TrueY�6�   �� 5r   "   -   5        $ checkBox_Birth��5r   3   $ 9��6+   $��Birth��6K   $
 TrueY�6v   5s      5t      5u      �� 5y      $��3��6   $��Actions��6,   .��5z      � $��Center=�6   $��Center=�6:    5{      �� 5|   "   $
��Auto �63   �� 5}   "   $
��Auto �63   .+�5�      �� $
��Auto��6)   $��0��67   .+�5�   "   �� -   5        $��
btn_insert��5�   )    + 'MaterialDesignFloatingActionLightButton#���  6;   $��Insert��6~   $��	0,0,20,20q�6�   6�   �� 5�   "   -   5        $��
btn_delete��5�   )   #���  6;   $��Delete��6~   $��0,0,20,0q�6�   6�   5�      �� 5�      $��1��6)   .+�5�   "   �� -   5        $��btn_edit��5�   )   #���  69   $��Edit Row��6{   $��0,0,0,20q�6�   6�   �� 5�   "   -   5        $��btn_editPass��5�   )   #���  6=   $��	Edit Pass��6   6�   5�      5�      5�      5�      5�      5�      5�      5�      