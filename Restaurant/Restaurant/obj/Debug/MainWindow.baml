   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Restaurant
Restaurant  5   	       Restaurant.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Restaurant     5   	     � Title$  Меню��5   	   $	��450��6   $	��400��6#   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��26* �6   �� 5      $��7* �6   .+�5   
   �� -   5         ��Name$ listBox��5      $��2��6N   $��0,0,0,91q�6b   $��2��6t   $
��Auto=�6�   $��10(�6�   $
��Bold"�6�   
���������5      �� 5       �� Color$ White��6"    �� Opacity$	 0.2Q�60   5      �� 5   
   -   5         ��Name$ button_Order_List��5      $-��'Додати до
замовлення��6,   $��1��6T   $��25,15,25,16q�6a   $��20(�6v   $
��Bold"�6�   ��5      �� 5       �� ImageSource$# /button backgruond orange.jpg��6   5      �� 5   
   -   5        $ button_Order��5      $��Замовити��6'   $��1��6:   $��25,15,25,16q�6G   $��1��6\   $��20(�6l   $
��Bold"�6z   ��5      �� 5      $" /button backgruond green.jpg��6   5       �� 5!   
   -   5        $ button_Admin��5!      $�� ��6'   $��
173,80,0,0q�62   $��20(�6F   $
��Bold"�6T   $��1��6�   $��1��6�   ��5"      �� 5#      $# /button backgruond orange.jpg��6   5%      ��5&   
   �� 5'      $ /background.jpg��6    j� Stretch$ UniformToFill=�67   $ 1Q�6O   	 j� TileMode$
	 None=�6[   5)      5*      