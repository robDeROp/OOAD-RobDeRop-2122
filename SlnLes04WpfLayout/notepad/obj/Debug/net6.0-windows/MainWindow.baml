   M S B A M L   `   `   `  ����B  >notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:notepadnotepad  5   	       notepad.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:notepad     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   ]� .+�5      o� $	��Top=�6   .@�5      m� -   5        $��_File��5      .@�5      m� -   5         m�Name$	 new��5       $
��_New��6-   6;   m� 5      -   5        $
 open��5       $��_Open��6.   6=   m� 5      -   5        $
 save��5       $��_Save��6.   ${�False��6P   m� 5      -   5        $ saveAs��5       $��_Save As...��60   6E   �� 5      m� 5      $��_Exit��6   5      m� 5      -   5        $��_Edit��5      .@�5      m� -   5        $	 cut��5      $
��_Cut��6,   6:   m� 5      -   5        $
 copy��5      $��_Copy��6-   6<   m� 5      -	   5        $ paste��5       $��_Paste��6/   ${�False��6S   5      m� 5      $��_Help��6   .@�5      m� -
   5        $��_About��5       60   5      5      �� 5      $��Bottom=�6   .@�5      �� -   5         ��Name$ lblCharsText��5      $��#Chars:��6.   �� 5      -   5        $ lblChars��5      $�� ��6*   5       �� 5!      -   5         ��Name$
 Tabs��5!      .@�5"      �� $��untitled��6   .��5#      �� -   5         ��Name$ 
txbContent��5#      $ �� HorizontalScrollBarVisibility$
 Auto=�62    �� TextWrapping$
 Wrap=�6W    �� AcceptsReturn$
 True��6k   " �� VerticalScrollBarVisibility$ Visible=�6�   5$      5%      5&      5'      5(      