   M S B A M L   `   `   `  ����C  ?slnAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:slnAdminslnAdmin  5   	       slnAdmin.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:slnAdmin     5   	     � Title$  Admin Login��5   	   $	��450��6   $	��800��6*   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFF5CBCB��6    � Offset$ 1Q�6-   � 5      $ 	#FFFBF7DC��6   5      .��5      � $��200px��6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ UserName��5      $��15 5 0 0q�6$   $
��12px(�67   $��gebruikersnaam��6G   $
��30px��6]   $	��150��6k   $��0��6w   ���	#B2FFFFFF���	#00ABADB3.��6�    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value��%_   '��       �� 5      " ��6   .�5      �� 	 �@��CornerRadius$
 15��65   5      5      .��6!   5      �� 5   
   -   5        $ Password��5      $��15 5 0 0q�6$   $
��12px(�67   $��
wachtwoord��6G   $
��30px��6Y   $	��150��6g   $��1��6s   ���	#B2FFFFFF���	#00ABADB3.��6�    5      ��%_   '��       �� 5      " ��6   .�5       �� 	 �@��CornerRadius$
 15��65   5!      5"      .��6!   5#      �� 5$   
   -   5         ��Name$ Submit��5$      $��Submit��6!   $
��40px��62   $��150px��6@   $��2��6N   
���   ����	#FFDE3D3D$
��Bold"�6�   
���   �$	��2pxq�6�    5%      ��%_   '��       �� 5&      " ��6   .�5'      �� 	 �@��CornerRadius$
 20��65   5(      5)      5*      �� 5+   
   -   5         ��Name$ Message��5+      $��3��6!   5,      5-      