   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   �� $��60��6   $��Images\Bier.webp��6   $��60��69   $��1��6E   $��0��6R   $��Right=�6b   �� 5   
   $��60��6   $��Images\Wijn.jpg��6   $��60��68   $��2��6D   $��0��6Q   $��Right=�6a   �� 5   
   $��60��6   $��Images\Sterkedrank.jpg��6   $��60��6?   $��3��6K   $��0��6X   $��Right=�6h   �� 5   
   -   5         ��Name$ sliderGlazenBier��5      $
��auto��6+   $��20��68    � Maximum$ 5Q�5       � Minimum$ 0Q�6   $��1��6%   $��1��62    � SmallChange$ 1Q�6o   5      �� 5   
   -   5        $ sliderGlazenWijn��5      $
��auto��6+   $��20��68   $ 5Q�5      $ 0Q�6   $��2��6%   $��1��62   $ 1Q�6o   5      �� 5   
   -   5        $ sliderGlazenSterke��5      $
��auto��6-   $��20��6:   $ 5Q�5       $ 0Q�6   $��3��6%   $��1��62   $ 1Q�6q   5!      �� 5"   
   -   5         ��Name$ lblAlcoholGehalte��5"      $��Alcohol gehalte:��6+   $��4��6F   $��0��6S   $��Right=�6c   $��Center=�6   �� 5#   
   -   5         ��Name$ rectAlcoholGehalte��5#      $
��Left=�60   $��Center=�6K   $��20��6f   $��30��6r   ���	#FFC0E86A$��4��6�   $��1��6�   �� 5$   
   -   5        $ lblBierGlazen��5$      $��glazen��6'   $��1��69   $��2��6F   $
��Left=�6V   $��Center=�6q   �� 5%   
   -   5        $ lblWijnGlazen��5%      $��glazen��6'   $��2��68   $��2��6E   $
��Left=�6U   $��Center=�6p   �� 5&   
   -   5        $ lblSterkeGlazen��5&      $��glazen��6)   $��3��6:   $��2��6G   $
��Left=�6W   $��Center=�6r   �� 5'   
   -	   5        $ lblTitle��5'      $��Alcohol-Gehalte��6"   $��0��6<   $��0��6I   $��Right=�6Y   $��Center=�6u   5)      5*      