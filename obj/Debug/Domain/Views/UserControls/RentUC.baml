   M S B A M L   `   `   `  ����I  EDapperRentACar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:DapperRentACar.Domain.Views.UserControls(DapperRentACar.Domain.Views.UserControls  5      5    /DapperRentACar.Domain.Views.UserControls.RentUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:DapperRentACar.Domain.Views.UserControls     5      $	��450��5      $	��320��5	      $��
20,10,20,0q�5
      .��5      �� $��4q�6     �� CornerRadius$  2��5      
������� �� Padding$ 10q�5      ��5      �� *BorderColor+��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 �����6/   �� 5       � ��$ 0q�64    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  �@J�Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   "      Color$ Black��63   	   Opacity$		 0.5Q�6B   
   
BlurRadius$
 2Q�6P      RenderingBias$ Performance=�6_   5      5      5      ._�5!   
   �  � RowDefinitions 5"      �� 5#      $��5* �6    6.   �� 5$      $
��1.5* �6    60   �� 5%      6"   �� 5&      6"   �� 5'      6"   �� 5(      6"   �� 5)      $��2* �6    6.   .+�5,      � $��0��6   .+�5-      �� -   5         ��Name$ Image��5.      $��UniformToFill=�5-      $��	0,0,0,-42q�5.   '   50      51      � 53      $��2��6   .+�54      �� $��20(�55      $��	ExtraBold"�56      
���   �$��10,0,0,0q�58      $��Cascadia Code SemiBold})�59      ��54      �� *Client.Username+5:      5;      � 5=      $��3��6   .+�5>      �� $��10,0,0,0q�5?      
���   �$��20(�5A      $��Cascadia Code SemiLight})�5B      $��2��6B   ��5>      �� *Client.Email+5C      5D      � 5F      $��4��6   .+�5G      �� $��10,0,0,0q�5H      
���   �$��20(�5J      $��Cascadia Code SemiLight})�5K      ��5G      �� *RentStartDate+5L      5M      � 5O      $��5��6   .+�5P      �� $��10,0,0,0q�5Q      $��20(�5R      
���   �$��Cascadia Code SemiLight})�5T      ��5P      �� *RentEndDate+5U      5V      � 5X      $��6��6   .+�5Y      ��    MyButtonStyle2#��[  5Z      $��
Send Email��5[      ��5Y      �� *	SendEmail+5\      5]      5^      5_      5`      