   M S B A M L   `   `   `  ����M  IWpfPaswoordChecker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfPaswoordCheckerWpfPaswoordChecker  5   	   #    WpfPaswoordChecker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WpfPaswoordChecker     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $	��300��6   $	��300��6    � RowDefinitions 5
   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��2* �6#   .+�5      �� -   5         ��Name$ lblWachtwoord��5      $	��Top=�6+   $
��Left=�6C   $��
Wachtoord:��6^   $
��auto��6s   $
��auto��6�   $��0��6�   �� 5      -   5         ��Name$ txbPasswoord��5      $	��Top=�6,   $
��Left=�6D   $�� ��6_   $
��auto��6g   $	��150��6u   $��1��6�   6�   5      � 5   
   $��1��6   .+�5      �� -   5        $ lblAchtKarakters��5      $	��Top=�6.   $
��Left=�6F   $��Minimum 8 karakters lang��6a   $
��auto��6�   $
��auto��6�   ���	#FFFD0202$��0��6�   5      � 5   
   $��2��6   .+�5      �� -   5        $ lblKleineletter��5      $	��Top=�6-   $
��Left=�6E   $��Minimum een kleine letter��6`   $
��auto��6�   $
��auto��6�   ���	#FFFD0202$��0��6�   5       � 5!   
   $��3��6   .+�5"      �� -   5        $ lblHoofdletter��5"      $	��Top=�6,   $
��Left=�6D   $��Minimum een hoofdletter��6_   $
��auto��6�   $
��auto��6�   ���	#FFFD0202$��0��6�   5#      � 5$   
   $��4��6   .+�5%      �� -   5        $ lblEenCijfer��5%      $	��Top=�6*   $
��Left=�6B   $��Minimum een cijfer��6]   $
��auto��6z   $
��auto��6�   ���	#FFFD0202$��0��6�   5&      � 5'   
   $��5��6   .+�5(      �� -   5        $ lblVreemdKarakter��5(      $	��Top=�6/   $
��Left=�6G   $!��Minimum een vreemd karakter��6b   $
��auto��6�   $
��auto��6�   $��0��6�   ���	#FFFD0202��6�   Z� 6�   5)      � 5*   
   $��6��6   .+�5+      �� -   5         ��Name$ btnRegistreer��5+      ${�False��6,   $	��Top=�6>   $
��Left=�6V   $��
Registreer��6q   $
��auto��6�   $
��auto��6�   $��0��6�   6�   5,      5-      5.      