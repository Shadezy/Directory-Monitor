   M S B A M L   `   `   `  ����B  >Midterm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MidtermMidterm  5   	       Midterm.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Midterm     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ lbl_err��5
      $�� ��6!   $
��Left=�6,   $��	10,55,0,0q�6G   $	��Top=�6Z   �� 5   
   -   5        $ lbl_current��5      $�� ��6%   $
��Left=�60   $��
230,56,0,0q�6K   $	��Top=�6_   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dg_content��5      $
��Left=�6'   $	��325��6B   $��	10,87,0,0q�6O   $	��Top=�6b   $	��774��6z      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Extension��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   ��  �� Path$ 	Extension�6{     5      $ FileName��6%    . $	 150 6k    6I   �� $ Filename�6y     5      $
 Path��6%    . $	 150 6c    6E   �� $
 Path�6q     5      $ Event��6%    . $	 150 6e    6F   �� $ Event�6s     5      $ 	Date/Time��6%    . $	 150 6h    6J   �� $
 Date�6v   5      o� 5   
   -   5        	 o�Name$
	 menu��5      $
��Left=�6   $��23��68   $	��Top=�6D   $	��794��6\   .@�5      m� -   5        
 m�Name$
 	menu_file��5      $��_File��6*   .@�5      m� -   5        $
 menu_file_start��5      $��Sta_rt��6L   {�. 6\   m� 5      -   5        $
 menu_file_stop��5      $��_Stop��6J   {�.  6Y   m� 5      -	   5        $
 menu_file_db��5      $��_Query Database��61   6J   m� 5      -
   5        $
 menu_file_create��5      $��_Create Database��65   6m   m� 5      -   5        $
 menu_file_close��5      $��Clos_e��6K   5      m� 5       -   5        $
 	menu_edit��5       $��_Edit��6B   5!      m� 5"      -   5        $
 	menu_help��5"      $��_Help��6*   .@�5#      m� -   5        $
 menu_help_about��5#      $��_About��6L   5$      5%      �� 5&   
   -   5        $ 
lbl_db_err��5&      $�� ��6$   $
��Left=�6/   $��
334,56,0,0q�6J   $	��Top=�6^   c� 5'   
   $��30��6   $	��Top=�6   $��0,23,-0.4,0q�66   $
��Left=�6K   $	��794��6f   $��1��6r   .@�5)      �� -   5         ��Name$ txt_path��5)      $
��Left=�6(    � ToolTip$ Enter the path here��6C   $��23��6a    �� TextWrapping$ NoWrap=�6m   $	��C:\��6�   $	��Top=�6�   $	��100��6�   .��6�   5*      �� 5,      -   5         ��Name$ 	btn_start��5,      $
��Left=�6(   $��23��6C   $* $Starts monitoring the specified path��6O   $	��Top=�6~   $��30��6�   .��5-      �� $��img/start.png��6   5.      �� 50      -   5        $ btn_stop��50      $
��Left=�6'   $) #Stops monitoring the specified path��6B   $	��Top=�6p   $��23��6�   $��30��6�   {�.  .��51      �� $��img/stop.png��6   60   52      �� 54      -   5        $ btn_create_db��54      $
��Left=�6,   $- 'Creates a database (Opens a new window)��6G   $	��Top=�6y   $��23��6�   $��30��6�   .��55      �� $��img/create.png��6   62   56      �� 58      -   5        $ 	btn_write��58      $
��Left=�6(   $@ :Writes the log to a selected database (Opens a new window)��6C   $	��Top=�6�   $��30��6�   $��
0,0,0,-0.6q�6�   $��23��6�   .��59      �� $��img/write.png��6   61   5:      �� 5<      -   5        $ txt_extensions��5<      $
��Left=�6.   $ Enter extension here��6I   $��23��6h   $
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $��58��6�   .��6�   5=      �� 5?      -   5         ��Name$ cmb_extensions��5?      $
��Left=�6/   $	��Top=�6J   $��23��6b   $��58��6�   5@      �� 5B      -   5        $ btn_extensions��5B      $
��Left=�6-   $[ UConfirms that you want to use the filter selected (Empty = all fields)(Input periods)��6H   $	��Top=�6�   $��23��6�   $��30��6�   .��5C      �� $��img/submit.png��6   62   5D      �� 5F      -   5        $ lbl_db_name��5F      $	��Top=�6)   $��5q�6A   6O   �� 5G      -   5        $ 	btn_clear��5G      $��Right=�6(   $@ :Clears the list (Does not actually delete the information)��6D   $��Center=�6�   $��23��6�   $��30��6�   $��0,-2,0,0q�6�   .��5H      �� $��img/clear.png��6   5I      5K      5M      5N      