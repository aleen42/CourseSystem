   M S B A M L   `   `   `  ����S  O教师选课管理系统, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:教师选课管理系统教师选课管理系统  5   	   &     教师选课管理系统.Loading   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8local&clr-namespace:教师选课管理系统     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowStyle$
  None=�5   	    � AllowsTransparency .  � Title$ 
MainWindow��5	   	   $	��534��6   $	��950��6)   ��65   Z�  � 	Resources 5         system_button g� RepeatBehavior g� 	BeginTime �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  load��%b  &	        &	     �� 5   
   $ 1x��6+   .��5      U� $ 00:00:0X�6,   $ system_button��6@   $ (UIElement.Opacity)�6f   .\�5        $ 0:0:0��6'   $	 0Q�67     5      $ 0:0:10.8��6'   $	 0Q�6:     5      $ 0:0:12��6'   $	 1Q�68   5      5      �� 5   
   $ 1x��6"   .��5      U� $ 00:00:0X�6,   $
 load��6@   $ (UIElement.Opacity)�6]   .\�5        $ 0:0:0��6'   $	 0Q�67     5      $ 0:0:3��6'   $	 1Q�67     5      $ 0:0:8.5��6'   $	 1Q�69     5      $ 0:0:10.8��6'   $	 0Q�6:   5      5      5      
 � Triggers
 5      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� #��[  6   �� 5      #��[ 6   5!      .��5#      � ��5$   
   �� 5%       �� ImageSource$% Image_background/background.png��6    �� Opacity$	 0.8Q�6G   .+�5'   
   +   %教师选课管理系统.FlashLoading  -   5          Name$
 load��5'      $��346,372,-346,112q�6A    J� Opacity$ 0Q�6[   ��6+   Z� 6[   #   教师选课管理系统.Gear  5(   
   -   5          Name$
 gear��5(      $��
15,0,-15,0q�6K   ��65   Z� 6K   *   $教师选课管理系统.MetroProBar  5)   
   -   5          Name$ metro��5)      $��183,407,97,72q�6S   ��6=   Z� 6S   �� 5*   
   -   5         ��Name$ system_button��5*      $��Techer system��6(   $
��Left=�6@   $��409,438,0,0q�6[   $	��Top=�6p   $	��148��6�   $��41��6�   $��16(�6�   ���	#FF4F3050���	#FFFFAB89��5+      �� 5,       �� 
TargetType" ��6"   .R�5-      ��  ��Name$ Teacher��6   ���	#FFDF8679$��1,1,5,5q�5/      #��z��50      ._�51      �� $��Center=�6+   $��Center=�6H   52      54      56      57      58      