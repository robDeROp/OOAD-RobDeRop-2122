   M S B A M L   `   `   `  ����H  DWpfEscapeGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfEscapeGameWpfEscapeGame  5   	       WpfEscapeGame.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfEscapeGame     5   	     � Title$  Escape game��5   	   $��568.8��6   $	��800��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ txtRoomDesc��5
       �� Padding$ 10,10,10,10q�6)   $
��Left=�6?   $��63��6Z   $��	24,10,0,0q�6f   $
��Wrap=�6y   $	��Top=�6�   $	��743��6�   $��16(�6�   ���	#FFF9F5F56�   �� 5      -   5         ��Name$ 
lblMessage��5      $��10,10,10,10q�6"   $�� ��68   $
��Left=�6C   $��45��6^   $��	24,85,0,0q�6j   $	��Top=�6}   $	��743��6�   ���	#FFF9F5F5$��16(�6�   ���	#FF0000996�   �� 5      $��
Room items��6   $
��Left=�6#   $��26��6>   $��
24,150,0,0q�6J   $	��Top=�6^   $	��112��6v   �� 5      $��
Room doors��6   $
��Left=�6#   $��26��6>   $��
24,340,0,0q�6J   $	��Top=�6^   $	��112��6v   �� 5      -   5         ��Name$ btnCheck��5      $��<- CHECK��6!   $
��Left=�67   $��35��6R   $��313,176,0,0q�6^   $	��Top=�6s   $	��161��6�   ${�False��6�   6�   �� 5   
   -   5        $ btnOpenWith��5      $��<- OPEN WITH ->��6&   $
��Left=�6F   $��35��6a   $��313,370,0,0q�6m   $	��Top=�6�   $	��161��6�   ${�False��6�   6�   �� 5   
   -   5        $ btnEnter��5      $��<- ENTER��6#   $
��Left=�69   $��35��6T   $��313,415,0,0q�6`   $	��Top=�6u   $	��161��6�   ${�False��6�   6�   �� 5      -   5        $ 	btnPickUp��5      $��
PICK UP >>��6"   $
��Left=�6=   $��35��6X   $��313,256,0,0q�6d   $	��Top=�6y   $	��161��6�   ${�False��6�   6�   �� 5   
   -   5        $ btnDrop��5      $��<< DROP��6"   $
��Left=�6:   $��35��6U   $��313,300,0,0q�6a   $	��Top=�6v   $	��161��6�   ${�False��6�   6�   �� 5      -   5        $ btnUseOn��5      $��<- USE ON ->��6!   $
��Left=�6>   $��35��6Y   $��313,216,0,0q�6e   $	��Top=�6z   $	��161��6�   ${�False��6�   6�   �� 5      -	   5         ��Name$ lstRoomItems��5      $
��Left=�6&   $	��155��6A   $��
24,176,0,0q�6N   $	��Top=�6b   $	��234��6z   6�   �� 5      $��Picked up items��6   $
��Left=�6(   $��26��6C   $��528,150,0,0q�6O   $	��Top=�6d   $	��112��6|   �� 5      -
   5        $ 
lstMyItems��5      $
��Left=�6$   $	��155��6?   $��528,176,0,0q�6L   $	��Top=�6a   $	��239��6y   6�   �� 5      -   5        $ lstRoomsDoors��5      $
��Left=�6'   $��80��6B   $��
24,370,0,0q�6N   $	��Top=�6b   $	��234��6z   6�   �� 5      -   5         ��Name$ ImgRoom��5      $��534,355,166,98q�6   5      5      