   M S B A M L   `   `   `  ����@  <Email, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EmailEmail  5   	       Email.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   localclr-namespace:Email  5   	     � Title$  
UserWindow��5	   	   ���#121212$	��450��61   $	��800��6>    � WindowStartupLocation$ CenterScreen=�6J   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 
FoldersLbx��5      $��1��6&   $��0��63   $��4��6C   ���#212121$��0q�6i   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 �����63   5      5      �� 5   
   -   5         ��Name$
 Send��5      $
��Send��6   $��45��6.   $��0��6:   $��Center=�6J   +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 8��6e   $��	38,0,26,0q�6�   ���#2979FF
�������$��0q�6�   
 � 	Resources
 5      ��%R   '��       �� 5      " ��6   .�5       ��  � ��$ 16(�61   5!      5"      5#       � 5$   
   -   5          �Name$ 	PageFrame��5$      $��0��6#   $��1��60   $��5��6@     � NavigationUIVisibility$ Hidden=�6Q   5%      5&      