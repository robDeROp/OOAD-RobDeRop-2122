   M S B A M L   `   `   `  ����C  ?slnAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:slnAdminslnAdmin  5   	       slnAdmin.Add_Edit_Pet   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:slnAdmin     5   	     � Title$  Add_Edit_Pet��5   	   $	��512��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��11* �6   �� 5      $	��67* �6   �� 5      $
��304* �6   �� 5      $	��18* �6   �� 5      $
��400* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ 	btnCancel��5      $��Cancel��6$   $��0��65   $��8��6E   ���	#FFF9C0C0$��4��6�   �� 5   
   -   5        $ btnSave��5      $
��Save��6"   $��4��61   $��8��6A   ���	#FFD5FFCA6e   �� 5   
   $	��ID:��6   $��0��6   $
��Left=�6.   $��Center=�6I   $��2��6d   �� 5    
   $��Naam:��6   $��1��6    $��0��6-   $
��Left=�6=   $��Center=�6X   $��2��6s   �� 5!   
   $��
Opmerking:��6   $��2��6%   $��0��62   $
��Left=�6B   $��Center=�6]   $��2��6x   �� 5"   
   $��	Geslacht:��6   $��3��6$   $
��Left=�61   $��Center=�6L   $��2��6g   �� 5#   
   $��Groote:��6   $��4��6"   $
��Left=�6/   $��Center=�6J   $��2��6e   �� 5$   
   $��	Leeftijd:��6   $��5��6$   $��0��61   $
��Left=�6A   $��Center=�6\   $��2��6w   �� 5%   
   $��	Eigenaar:��6   $��6��6$   $��0��61   $
��Left=�6A   $��Center=�6\   $��2��6w   �� 5&   
   $��Type:��6   $��7��6    $��0��6-   $
��Left=�6=   $��Center=�6X   $��2��6s   �� 5(   
   -   5         ��Name$ txtID��5(      $��0��6!   $��4��6.   $��20��6>    �� 
IsReadOnly . $��	0,17,0,11q�6\   �� 5)   
   -   5        $ txtNaam��5)      $��1��6#   $��4��60   $��20��6@   $��	0,17,0,11q�6L   �� 5*   
   -   5        $ txtOpmerking��5*      $��2��6(   $��4��65   $��20��6E   $��	0,17,0,12q�6Q   �� 5+   
   -   5         ��Name$ 
cbGeslacht��5+      $��3��6'   $��4��64   $��25��6D   $��Center=�6P   �� 5,   
   -   5        $ 	txtGroote��5,      $��4��6%   $��4��62   $��20��6B   $��	0,17,0,11q�6N   �� 5-   
   -   5        $ txtLeeftijd��5-      $��5��6'   $��4��64   $��20��6D   $��	0,17,0,11q�6P   �� 5.   
   -	   5        $ cbUser��5.      $��6��6#   $��4��60   $��25��6@   $��Center=�6L   �� 5/   
   -
   5        $ cbType��5/      $��7��6#   $��4��60   $��25��6@   $��Center=�6L   50      51      