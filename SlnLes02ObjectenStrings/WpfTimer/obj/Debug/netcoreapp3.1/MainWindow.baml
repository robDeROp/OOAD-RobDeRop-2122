   M S B A M L   `   `   `  ����C  ?WpfTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfTimerWpfTimer  5   	       WpfTimer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfTimer     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $	��200��6   $	��100��6    � ColumnDefinitions 5
   
   �� 5      $
��1.5* �6   �� 5      $��2* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��1* �6    �� 5      $��1* �6    .+�5      �� -   5         ��Name$ btnStart��5      $
{�True��6'   $��Center=�68   $��Center=�6S   $��Start��6p   $
��auto��6�   $��50��6�   $��0��6�   6�   �� 5      -   5        $ btnStop��5      ${�False��6&   $��Center=�68   $��Center=�6S   $
��Stop��6p   $
��auto��6   $��50��6�   $��1��6�   6�   �� 5      -   5        $ btnReset��5      ${�False��6'   $��Center=�69   $��Center=�6T   $��Reset��6q   $
��auto��6�   $��50��6�   $��2��6�   6�   5      � 5   
   $��1��6    5      �� 5      $��1* �6    �� 5      $
��2.2* �6    .+�5      �� -   5         ��Name$ lblTijd��5      $��Center=�6%   $��Right=�6@   $��00:00��6\   $
��auto��6l   $
��auto��6z   $��20(�6�   �� 5      -   5         ��Name$ rectMin��5      $
��Left=�6)   $��10��6D   $��10 0 0 0q�6P   $��1��6b   
���   �$��Bottom=�6~   $��30��6�   �� 5      -   5        $ rectSec��5      $
��Left=�6)   $��10��6D   $��50 0 0 0q�6P   $��1��6b   
���   �$��Bottom=�6~   $��30��6�   5!      5#      5$      