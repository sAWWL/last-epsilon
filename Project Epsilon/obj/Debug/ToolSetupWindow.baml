   M S B A M L   `   `   `  ����  Project Epsilon%    Project_Epsilon.ToolSetupWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
Tool Setup��5   	   $	��415��6   $��675.5��6*   $	��400��68   $	��650��6H    � 
ResizeMode$ NoResize=�5   	   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5      $ 	#FFBFCEDA��6   $ 0.734Q�61   � 5      $ 	AliceBlue��6   $ 0.228Q�61   � 5      $ 	#FF030C13��6   $ 1Q�61   � 5      $ 	#FF4892C9��6   $ 1Q�61   � 5      $ 	#FF2F73AD��6   $
 0.99Q�61   5      .+�5   
   �� -   5         ��Name$ ToolConfCheckBox��5      $!��Tool Confirmation Required?��6-   $��
0,120,0,90q�6T   $	��Top=�6h   $��Center=�6�   $
��Bold"�6�   
���   �$��16(�6�   �� 5   
   -   5         ��Name$ ToolUDILabel��5      $��	Tool UDI:��6&   $��150,175,0,2q�6:   $y�Hidden=�6O   $
��Bold"�6c   
���   �$��16(�6�   �� 5   
   -   5         ��Name$ ToolUDITextbox��5      $y�Hidden=�6*   	 �� 	MaxLength$	 40��6>   $��243,180,96,175q�6M   $��Consolas)�6e   6{   �� 5   
   -   5        $ NumCavsLabel��5      $%��Number of Cavities in the Tool?��6&   $��150,216,0,-16q�6P   $y�Hidden=�6g   $
��Bold"�6{   
���   �$��16(�6�   �� 5   
   -   5        $ NumCavsTextbox��5      $	 1��6*   $y�Hidden=�68   $��402,218,232,136q�6�   
 J� RenderTransformOrigin$
 	0.65,1.35&�6�   �� 5   
   -   5         ��Name$ BackButton2��5      $��< Back��6&   $��494,303,33,39q�6:   {�. $��16(�6u   $
 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.488Q�6&   T� 5      5       5"      �� 5#   
   -   5        $ ErrorMessage��5#      $X��RTool UDI and # of Cavities are Required when Tool Confirmation Required is Checked��6&   $
��Left=�6�   $��	10,39,0,0q�6�   $	��Top=�6�   $
��Bold"�6�   
���  ��$y�Visible=�6�   
�������$��16(�6  5%      5&      