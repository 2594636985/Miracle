   M S B A M L   `   `   `  ����R  NMiracle.Desktop.Toolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Miracle.Desktop.Toolkit.Controls Miracle.Desktop.Toolkit.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 "  RotatingPlaneProgressRingStyle  �� 
TargetType9    3Miracle.Desktop.Toolkit.Controls.ModernProgressRing �� Property �� Value 
 Accent �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� RepeatBehavior g� Duration	 �� 
TargetName
 �� TargetProperty R� KeyTime  System.Windows.Visibility   Visible R� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value �� 	KeySpline �Name ��Name J� RenderTransformOrigin ! DoubleBounceProgressRingStyle A�Name J� Opacity  WaveProgressRingStyle � ColumnDefinitions �� ScaleY # WanderingCubesProgressRingStyle � RowDefinitions �� CenterX �� CenterY �� CenterX �� CenterY  PulseProgressRingStyle   ChasingDotsProgressRingStyle   ThreeBounceProgressRingStyle g� 	BeginTime  CircleProgressRingStyle � 	Resources 	 Key �� Angle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;controls.clr-namespace:Miracle.Desktop.Toolkit.Controls  5      %�|  &	        &	     &	 �    &	     &	 �3    &	 �:    &	 �E    &	 �U    �� 5      "    63   .�5   
   ��  � ��
 ���� 6'   �� 5   
    � ��# �  6'   �� 5   
    �@J�IsHitTestVisible .  6-   �� 5	   
    � ��$ Center=�60   �� 5
   
    � ��$ Center=�6.   �� 5   
    � ��$ 20��6&   �� 5   
    � ��$ 20��6%   �� 5   
    � �� .  6&   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� #��z��6   #��z��5      #��z��5       5        5      
SizeStates��. 5   "     	Large��6.     5   "   	Small��6.   5        5      ActiveStates��. 5   "     Inactive��6.     5   "   
Active��. 5   &   �� $ Forever��61   .��5   *   T� $ 0D�6H   $
	 Ring��6U   $
 
Visibility�6r   ..�5   .   i� $ 0��6E   # Z 6Q   5   +   U� 5    *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6H   $	 ProgressElement��6�   .\�5!   .     $ 0��6C   $ -1Q�6O   �� 5"   .   $ 0:0:0.6��6C   $ 1Q�6U   $ 0.42,0 0.58,1��6_   5#   +   U� 5$   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement��6�   .\�5%   .     $ 0:0:0.6��6C   $ 1Q�6U   �� 5&   .   $ 0:0:1.2��6C   $ -1Q�6U   $ 0.42,0 0.58,1��6`   5'   +   5(   '   5)   #   5*      ._�5,      � $
 Ring��6   #��z��5-      $y�	Collapsed=�5.      $��LeftToRight=�5/      .+�51      �� $ ProgressElement��6(   #��z��6A   $ .5,.5&�6e   z�52   "   �� 53   &   55      56      57      58      5:      5;      �� 5=      "    62   .�5>   
   ��  � ��
 ���� 6'   �� 5?   
    � ��# �  6'   �� 5@   
    �@J�IsHitTestVisible .  6-   �� 5A   
    � ��$ Center=�60   �� 5B   
    � ��$ Center=�6.   �� 5C   
    � ��$ 32��6&   �� 5D   
    � ��$ 32��6%   �� 5E   
    � �� .  6&   �� 5F   
    � �� 5G      �� 5H      "   6"   .R�5I      �� #��z��6   #��z��5J      #��z��5K       5M        5N      
SizeStates��. 5O   "     	Large��6.     5P   "   	Small��6.   5Q        5R      ActiveStates��. 5S   "     Inactive��6.     5T   "   
Active��. 5U   &   �� $ Forever��61   .��5V   *   T� $ 0D�6H   $
	 Ring��6U   $
 
Visibility�6r   ..�5W   .   i� $ 0��6E   # Z 6Q   5X   +   U� 5Y   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6H   $	 ProgressElement1��6�   .\�5Z   .     $ 0��6C   $ 0Q�6O   �� 5[   .   $ 0:0:1��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   �� 5\   .   $ 0:0:2��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   5]   +   U� 5^   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement1��6�   .\�5_   .     $ 0��6C   $ 0Q�6O   �� 5`   .   $ 0:0:1��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   �� 5a   .   $ 0:0:2��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   5b   +   U� 5c   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6H   $	 ProgressElement2��6�   .\�5d   .     $ 0��6C   $ 1Q�6O   �� 5e   .   $ 0:0:1��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   �� 5f   .   $ 0:0:2��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   5g   +   U� 5h   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement2��6�   .\�5i   .     $ 0��6C   $ 1Q�6O   �� 5j   .   $ 0:0:1��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   �� 5k   .   $ 0:0:2��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   5l   +   5m   '   5n   #   5o      ._�5q      � $
 Ring��6   #��z��5r      $y�	Collapsed=�5s      $��LeftToRight=�5t      .+�5u      A� $ ProgressElement1��6&   #��z��6@   $	 0.6Q�6d   $ 0.5,0.5&�6r   z�5v   "   �� 5w   &   5y      A� 5z      $ ProgressElement2��6&   #��z��6@   $	 0.6Q�6d   $ 0.5,0.5&�6r   z�5{   "   �� 5|   &   5~      5      5�      5�      5�      5�      �� 5�      "    6*   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � ��# �  6'   �� 5�   
    �@J�IsHitTestVisible .  6-   �� 5�   
    � ��$ Center=�60   �� 5�   
    � ��$ Center=�6.   �� 5�   
    � ��$ 32��6&   �� 5�   
    � ��$ 32��6%   �� 5�   
    � �� .  6&   �� 5�   
    � �� 5�      �� 5�      "   6"   .R�5�      �� #��z��6   #��z��5�      #��z��5�       5�        5�      
SizeStates��. 5�   "     	Large��6.     5�   "   	Small��6.   5�        5�      ActiveStates��. 5�   "     Inactive��6.     5�   "   
Active��. 5�   &   �� $ Forever��61   .��5�   *   T� $ 0D�6H   $
	 Ring��6U   $
 
Visibility�6r   ..�5�   .   i� $ 0��6E   # Z 6Q   5�   +   U� 5�   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement1��6�   .\�5�   .     $ 0��6C   $	 0.4Q�6O   �� 5�   .   $ 	0:0:0.240��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�   .   $ 	0:0:0.480��6C   $	 0.4Q�6W   $ 0.42,0 0.58,1��6c     5�   .   $ 	0:0:1.200��6C   $	 0.4Q�6W   5�   +   U� 5�   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement2��6�   .\�5�   .     $ 0��6C   $	 0.4Q�6O   �� 5�   .   $ 	0:0:0.340��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�   .   $ 	0:0:0.580��6C   $	 0.4Q�6W   $ 0.42,0 0.58,1��6c     5�   .   $ 	0:0:1.300��6C   $	 0.4Q�6W   5�   +   U� 5�   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement3��6�   .\�5�   .     $ 0��6C   $	 0.4Q�6O   �� 5�   .   $ 	0:0:0.440��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�   .   $ 	0:0:0.680��6C   $	 0.4Q�6W   $ 0.42,0 0.58,1��6c     5�   .   $ 	0:0:1.400��6C   $	 0.4Q�6W   5�   +   U� 5�   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement4��6�   .\�5�   .     $ 0��6C   $	 0.4Q�6O   �� 5�   .   $ 	0:0:0.540��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�   .   $ 	0:0:0.780��6C   $	 0.4Q�6W   $ 0.42,0 0.58,1��6c     5�   .   $ 	0:0:1.500��6C   $	 0.4Q�6W   5�   +   U� 5�   *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement5��6�   .\�5�   .     $ 0��6C   $	 0.4Q�6O   �� 5�   .   $ 	0:0:0.640��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�   .   $ 	0:0:0.880��6C   $	 0.4Q�6W   $ 0.42,0 0.58,1��6c     5�   .   $ 	0:0:1.600��6C   $	 0.4Q�6W   5�   +   5�   '   5�   #   5�      ._�5�      � $
 Ring��6   #��z��5�      $y�	Collapsed=�5�       5�      �� 5�   "   $��6* �63   �� 5�   "   $��4* �63   �� 5�   "   $��6* �63   �� 5�   "   $��4* �63   �� 5�   "   $��6* �63   �� 5�   "   $��4* �63   �� 5�   "   $��6* �63   �� 5�   "   $��4* �63   �� 5�   "   $��6* �63   .+�5�      �� $ ProgressElement1��6(   $��0��6B   #��z��6R   $ 0.5,0.5&�6v   z�5�   "   �� 5�   &   $	 0.4Q�65   5�      �� 5�      $ ProgressElement2��6(   $��2��6B   #��z��6R   $ 0.5,0.5&�6v   z�5�   "   �� 5�   &   $	 0.4Q�65   5�      �� 5�      $ ProgressElement3��6(   $��4��6B   #��z��6R   $ 0.5,0.5&�6v   z�5�   "   �� 5�   &   $	 0.4Q�65   5�      �� 5�      $ ProgressElement4��6(   $��6��6B   #��z��6R   $ 0.5,0.5&�6v   z�5�   "   �� 5�   &   $	 0.4Q�65   5�      �� 5�      $ ProgressElement5��6(   $��8��6B   #��z��6R   $ 0.5,0.5&�6v   z�5�   "   �� 5�   &   $	 0.4Q�65   5�      5�      5�      5�      5�      5�      �� 5�      "    64   .�5�   
   ��  � ��
 ���� 6'   �� 5�   
    � ��# �  6'   �� 5�   
    �@J�IsHitTestVisible .  6-   �� 5�   
    � ��$ Center=�60   �� 5�   
    � ��$ Center=�6.   �� 5�   
    � ��$ 80��6#   �� 5�   
    � ��$ 80��6"   �� 5�   
    � �� .  6&   �� 5�   
    � �� 5�      �� 5�      "   6"   .R�5�      �� #��z��6   #��z��5�      #��z��5       5       5     
SizeStates��. 5  "     	Large��6.     5  "   	Small��6.   5       5     ActiveStates��. 5  "     Inactive��6.     5  "   
Active��. 5	  &   �� $ Forever��61   .��5
  *   T� $ 0D�6H   $
	 Ring��6U   $
 
Visibility�6r   ..�5  .   i� $ 0��6E   # Z 6Q   5  +   U� 5  *   $
 X�6H   $	 
Translate1��6f   .\�5  .   �� $ 0��6C   $ 0Q�6O   �� 5  .   $ 0:0:0.5��6C   $ 60Q�6U   $ 0.42,0 0.58,1��6`   �� 5  .   $ 0:0:1��6C   $ 60Q�6S   $ 0.42,0 0.58,1��6^   �� 5  .   $ 0:0:1.5��6C   $ 0Q�6U   $ 0.42,0 0.58,1��6_   �� 5  .   $ 0:0:2��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   5  +   U� 5  *   $
 Y�6H   $	 
Translate1��6f   .\�5  .   �� $ 0��6C   $ 0Q�6O   �� 5  .   $ 0:0:0.5��6C   $ 0Q�6U   $ 0.42,0 0.58,1��6_   �� 5  .   $ 0:0:1��6C   $ 60Q�6S   $ 0.42,0 0.58,1��6^   �� 5  .   $ 0:0:1.5��6C   $ 60Q�6U   $ 0.42,0 0.58,1��6`   �� 5  .   $ 0:0:2��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   5  +   U� 5  *   $
 ScaleX�6H   $	 Scale1��6k   .\�5  .   �� $ 0��6C   $ 1Q�6O   �� 5  .   $ 0:0:0.5��6C   $	 0.5Q�6U   $ 0.42,0 0.58,1��6a   �� 5  .   $ 0:0:1��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   �� 5  .   $ 0:0:1.5��6C   $	 0.5Q�6U   $ 0.42,0 0.58,1��6a   �� 5   .   $ 0:0:2��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   5!  +   U� 5"  *   $
 ScaleY�6H   $	 Scale1��6k   .\�5#  .   �� $ 0��6C   $ 1Q�6O   �� 5$  .   $ 0:0:0.5��6C   $	 0.5Q�6U   $ 0.42,0 0.58,1��6a   �� 5%  .   $ 0:0:1��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   �� 5&  .   $ 0:0:1.5��6C   $	 0.5Q�6U   $ 0.42,0 0.58,1��6a   �� 5'  .   $ 0:0:2��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   5(  +   U� 5)  *   $
 Angle�6H   $	 Rotate1��6j   .\�5*  .   �� $ 0��6C   $ 0Q�6O   �� 5+  .   $ 0:0:0.5��6C   $	 -90Q�6U   $ 0.42,0 0.58,1��6a   �� 5,  .   $ 0:0:1��6C   $
 -180Q�6S   $ 0.42,0 0.58,1��6`   �� 5-  .   $ 0:0:1.5��6C   $
 -270Q�6U   $ 0.42,0 0.58,1��6b   �� 5.  .   $ 0:0:2��6C   $
 -360Q�6S   $ 0.42,0 0.58,1��6`   5/  +   U� 50  *   $
 X�6H   $	 
Translate2��6f   .\�51  .   �� $ 0��6C   $ 0Q�6O   �� 52  .   $ 0:0:0.5��6C   $	 -60Q�6U   $ 0.42,0 0.58,1��6a   �� 53  .   $ 0:0:1��6C   $	 -60Q�6S   $ 0.42,0 0.58,1��6_   �� 54  .   $ 0:0:1.5��6C   $ 0Q�6U   $ 0.42,0 0.58,1��6_   �� 55  .   $ 0:0:2��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   56  +   U� 57  *   $
 Y�6H   $	 
Translate2��6f   .\�58  .   �� $ 0��6C   $ 0Q�6O   �� 59  .   $ 0:0:0.5��6C   $ 0Q�6U   $ 0.42,0 0.58,1��6_   �� 5:  .   $ 0:0:1��6C   $	 -60Q�6S   $ 0.42,0 0.58,1��6_   �� 5;  .   $ 0:0:1.5��6C   $	 -60Q�6U   $ 0.42,0 0.58,1��6a   �� 5<  .   $ 0:0:2��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   5=  +   U� 5>  *   $
 ScaleX�6H   $	 Scale2��6k   .\�5?  .   �� $ 0��6C   $ 1Q�6O   �� 5@  .   $ 0:0:0.5��6C   $	 0.5Q�6U   $ 0.42,0 0.58,1��6a   �� 5A  .   $ 0:0:1��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   �� 5B  .   $ 0:0:1.5��6C   $	 0.5Q�6U   $ 0.42,0 0.58,1��6a   �� 5C  .   $ 0:0:2��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   5D  +   U� 5E  *   $
 ScaleY�6H   $	 Scale2��6k   .\�5F  .   �� $ 0��6C   $ 1Q�6O   �� 5G  .   $ 0:0:0.5��6C   $	 0.5Q�6U   $ 0.42,0 0.58,1��6a   �� 5H  .   $ 0:0:1��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   �� 5I  .   $ 0:0:1.5��6C   $	 0.5Q�6U   $ 0.42,0 0.58,1��6a   �� 5J  .   $ 0:0:2��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   5K  +   U� 5L  *   $
 Angle�6H   $	 Rotate2��6j   .\�5M  .   �� $ 0��6C   $ 0Q�6O   �� 5N  .   $ 0:0:0.5��6C   $	 -90Q�6U   $ 0.42,0 0.58,1��6a   �� 5O  .   $ 0:0:1��6C   $
 -180Q�6S   $ 0.42,0 0.58,1��6`   �� 5P  .   $ 0:0:1.5��6C   $
 -270Q�6U   $ 0.42,0 0.58,1��6b   �� 5Q  .   $ 0:0:2��6C   $
 -360Q�6S   $ 0.42,0 0.58,1��6`   5R  +   5S  '   5T  #   5U     ._�5W     � $
 Ring��6   #��z��5X     $y�	Collapsed=�5Y      5Z     �� 5[  "   $��2* �63   �� 5\  "   $��4* �63   �� 5]  "   $��2* �63    5_     �� 5`  "   $��2* �60   �� 5a  "   $��4* �60   �� 5b  "   $��2* �60   .+�5e     �� $ ProgressElement1��6(   #��z��6B   $��0��6f   $��0��6v   $ 0.5,0.5&�6�   z�5f  "   V� 5g  &   .~�5h  *   �� 
Scale1��$ .5Q�6I   $ .5Q�6V   �� 5i  *   Rotate1��$ .5Q�6K   $ .5Q�6X   T� 5j  *   
Translate1��6=   5k  '   5m     �� 5o     $ ProgressElement2��6(   #��z��6B   $��2��6f   $��2��6v   $ 0.5,0.5&�6�   z�5p  "   V� 5q  &   .~�5r  *   �� 
Scale2��$ .5Q�6I   $ .5Q�6V   �� 5s  *   Rotate2��$ .5Q�6K   $ .5Q�6X   T� 5t  *   
Translate2��6=   5u  '   5w     5x     5y     5z     5|     5}     �� 5     "    6+   .�5�  
   ��  � ��
 ���� 6'   �� 5�  
    � ��# �  6'   �� 5�  
    �@J�IsHitTestVisible .  6-   �� 5�  
    � ��$ Center=�60   �� 5�  
    � ��$ Center=�6.   �� 5�  
    � ��$ 32��6&   �� 5�  
    � ��$ 32��6%   �� 5�  
    � �� .  6&   �� 5�  
    � �� 5�     �� 5�     "   6"   .R�5�     �� #��z��6   #��z��5�     #��z��5�      5�       5�     
SizeStates��. 5�  "     	Large��6.     5�  "   	Small��6.   5�       5�     ActiveStates��. 5�  "     Inactive��6.     5�  "   
Active��. 5�  &   �� $ Forever��61   .��5�  *   T� $ 0D�6H   $
	 Ring��6U   $
 
Visibility�6r   ..�5�  .   i� $ 0��6E   # Z 6Q   5�  +   U� 5�  *   $
 (UIElement.Opacity)�6H   $	 ProgressElement��6x   .\�5�  .     $ 0��6C   $ 1Q�6O   �� 5�  .   $ 0:0:1��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   5�  +   U� 5�  *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6H   $	 ProgressElement��6�   .\�5�  .     $ 0��6C   $ 0Q�6O   �� 5�  .   $ 0:0:1��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   5�  +   U� 5�  *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement��6�   .\�5�  .     $ 0��6C   $ 0Q�6O   �� 5�  .   $ 0:0:1��6C   $ 1Q�6S   $ 0.42,0 0.58,1��6]   5�  +   5�  '   5�  #   5�     ._�5�     � $
 Ring��6   #��z��5�     $y�	Collapsed=�5�     .+�5�     A� $ ProgressElement��6&   #��z��6?   $ 0.5,0.5&�6c   z�5�  "   �� 5�  &   5�     5�     5�     5�     5�     5�     �� 5�     "    61   .�5�  
   ��  � ��
 ���� 6'   �� 5�  
    � ��# �  6'   �� 5�  
    �@J�IsHitTestVisible .  6-   �� 5�  
    � ��$ Center=�60   �� 5�  
    � ��$ Center=�6.   �� 5�  
    � ��$ 32��6&   �� 5�  
    � ��$ 32��6%   �� 5�  
    � �� .  6&   �� 5�  
    � �� 5�     �� 5�     "   6"   .R�5�     �� #��z��6   #��z��5�     #��z��5�      5�       5�     
SizeStates��. 5�  "     	Large��6.     5�  "   	Small��6.   5�       5�     ActiveStates��. 5�  "     Inactive��6.     5�  "   
Active��. 5�  &   �� $ Forever��61   .��5�  *   T� $ 0D�6H   $
	 Ring��6U   $
 
Visibility�6r   ..�5�  .   i� $ 0��6E   # Z 6Q   5�  +   U� 5�  *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6H   $	 ProgressElement1��6�   .\�5�  .     $ 0��6C   $	 1.0Q�6O   �� 5�  .   $ 0:0:1��6C   $	 0.0Q�6S   $ 0.42,0 0.58,1��6_   �� 5�  .   $ 0:0:2��6C   $	 1.0Q�6S   $ 0.42,0 0.58,1��6_   5�  +   U� 5�  *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement1��6�   .\�5�  .     $ 0��6C   $	 1.0Q�6O   �� 5�  .   $ 0:0:1��6C   $	 0.0Q�6S   $ 0.42,0 0.58,1��6_   �� 5�  .   $ 0:0:2��6C   $	 1.0Q�6S   $ 0.42,0 0.58,1��6_   5�  +   U� 5�  *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6H   $	 ProgressElement2��6�   .\�5�  .     $ 0��6C   $ 0Q�6O   �� 5�  .   $ 0:0:1��6C   $	 1.0Q�6S   $ 0.42,0 0.58,1��6_   �� 5�  .   $ 0:0:2��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   5�  +   U� 5�  *   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6H   $	 ProgressElement2��6�   .\�5�  .     $ 0��6C   $ 0Q�6O   �� 5�  .   $ 0:0:1��6C   $	 1.0Q�6S   $ 0.42,0 0.58,1��6_   �� 5�  .   $ 0:0:2��6C   $ 0Q�6S   $ 0.42,0 0.58,1��6]   5�  +   U� 5�  *   $9
 3(UIElement.RenderTransform).(RotateTransform.Angle)�6H   $
	 Ring��6�   .\�5�  .     $ 0��6C   $ 0Q�6O     5�  .   $ 0:0:2��6C   $	 360Q�6S   5�  +   5�  '   5�  #   5�     ._�5�     � $
 Ring��6   #��z��5�     $y�	Collapsed=�5�     $ 0.5,0.5&�5�      5�     �� 5�  "   $��2* �60   �� 5�  "   $��* �60   �� 5�  "   $��2* �60    5�     �� 5�  "   $��* �63   �� 5�  "   $��3* �63   �� 5�  "   $��* �63   z�5�     �� 5�  "   .+�5     A� $ ProgressElement1��6&   $��0��6@   $��2��6M   $��1��6^   #��z��6n   $ 0.5,0.5&�6�   z�5  "   �� 5  &   5     A� 5     $ ProgressElement2��6&   $��1��6@   $��2��6M   $��1��6^   #��z��6n   $ 0.5,0.5&�6�   z�5  "   �� 5	  &   5     5     5     5     5     5     �� 5     "    61   .�5  
   ��  � ��
 ���� 6'   �� 5  
    � ��# �  6'   �� 5  
    �@J�IsHitTestVisible .  6-   �� 5  
    � ��$ Center=�60   �� 5  
    � ��$ Center=�6.   �� 5  
    � ��$ 32��6&   �� 5  
    � ��$ 32��6%   �� 5  
    � �� .  6&   �� 5  
    � �� 5     �� 5     "   6"   .R�5      �� #��z��6   #��z��5!     #��z��5"      5#       5$     
SizeStates��. 5%  "     	Large��6.     5&  "   	Small��6.   5'       5(     ActiveStates��. 5)  "     Inactive��6.     5*  "   
Active��. 5+  &   �� .��5,  *   T� $ 0D�6H   $
	 Ring��6U   $
 
Visibility�6r   ..�5-  .   i� $ 0��6E   # Z 6Q   5.  +   U� 5/  *   $ Forever��6H   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6a   $	 ProgressElement1��6�   .\�50  .     $ 0��6C   $	 0.0Q�6O   �� 51  .   $ 	0:0:0.560��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 52  .   $ 	0:0:1.120��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 53  .   $ 	0:0:1.400��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   54  +   U� 55  *   $ Forever��6H   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6a   $	 ProgressElement1��6�   .\�56  .     $ 0��6C   $	 0.0Q�6O   �� 57  .   $ 	0:0:0.560��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 58  .   $ 	0:0:1.120��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 59  .   $ 	0:0:1.400��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5:  +   U� 5;  *   $ Forever��6H   $ 	0:0:0.160X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement2��6�   .\�5<  .     $ 0��6C   $	 0.0Q�6O   �� 5=  .   $ 	0:0:0.560��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5>  .   $ 	0:0:1.120��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5?  .   $ 	0:0:1.400��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5@  +   U� 5A  *   $ Forever��6H   $ 	0:0:0.160X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement2��6�   .\�5B  .     $ 0��6C   $	 0.0Q�6O   �� 5C  .   $ 	0:0:0.560��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5D  .   $ 	0:0:1.120��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5E  .   $ 	0:0:1.400��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5F  +   U� 5G  *   $ Forever��6H   $ 	0:0:0.320X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement3��6�   .\�5H  .     $ 0��6C   $	 0.0Q�6O   �� 5I  .   $ 	0:0:0.560��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5J  .   $ 	0:0:1.120��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5K  .   $ 	0:0:1.400��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5L  +   U� 5M  *   $ Forever��6H   $ 	0:0:0.320X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement3��6�   .\�5N  .     $ 0��6C   $	 0.0Q�6O   �� 5O  .   $ 	0:0:0.560��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5P  .   $ 	0:0:1.120��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5Q  .   $ 	0:0:1.400��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5R  +   5S  '   5T  #   5U     ._�5W     � $
 Ring��6   #��z��5X     $y�	Collapsed=�5Y      5Z     �� 5[  "   $��3* �63   �� 5\  "   $��* �63   �� 5]  "   $��3* �63   �� 5^  "   $��* �63   �� 5_  "   $��3* �63    5a     �� 5b  "   $��4* �60   �� 5c  "   $��3* �60   �� 5d  "   $��4* �60   .+�5g     A� $ ProgressElement1��6&   $��1��6@   $��0��6M   #��z��6]   $ 0.5,0.5&�6�   z�5h  "   �� 5i  &   5k     A� 5m     $ ProgressElement2��6&   $��1��6@   $��2��6M   #��z��6]   $ 0.5,0.5&�6�   z�5n  "   �� 5o  &   5q     A� 5s     $ ProgressElement3��6&   $��1��6@   $��4��6M   #��z��6]   $ 0.5,0.5&�6�   z�5t  "   �� 5u  &   5w     5y     5z     5{     5}     5~     �� 5�     "    6,   .�5�  
   ��  � ��
 ���� 6'   �� 5�  
    � ��# �  6'   �� 5�  
    �@J�IsHitTestVisible .  6-   �� 5�  
    � ��$ Center=�60   �� 5�  
    � ��$ Center=�6.   �� 5�  
    � ��$ 32��6&   �� 5�  
    � ��$ 32��6%   �� 5�  
    � �� .  6&   �� 5�  
    � �� 5�     �� 5�     "   6"   .R�5�     �� #��z��6   #��z��5�     #��z��5�      5�     ���� 5�     ProgressRingEllipseStyle	 "  A�6E   .�5�  "   ��  �@J�Opacity$ 0Q�6<   �� 5�  "    � ��$
 Left=�6H   �� 5�  "    � ��$	 Top=�6F   5�     5�      5�       5�     
SizeStates��. 5�  "     	Large��6.     5�  "   	Small��6.   5�       5�     ActiveStates��. 5�  "     Inactive��6.     5�  "   
Active��. 5�  &   �� .��5�  *   T� $ 0D�6H   $
	 Ring��6U   $
 
Visibility�6r   ..�5�  .   i� $ 0��6E   # Z 6Q   5�  +   U� 5�  *   $ Forever��6H   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6a   $	 ProgressElement1��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6a   $	 ProgressElement1��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.100X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement2��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.100X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement2��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.200X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement3��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.200X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement3��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.300X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement4��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.300X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement4��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.400X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement5��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.400X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement5��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.500X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement6��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.500X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement6��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.600X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement7��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.600X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement7��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.700X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�6w   $	 ProgressElement8��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5�  +   U� 5�  *   $ Forever��6H   $ 	0:0:0.700X�6a   $9
 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�6w   $	 ProgressElement8��6�   .\�5�  .     $ 0��6C   $	 0.0Q�6O   �� 5�  .   $ 	0:0:0.480��6C   $	 1.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5�  .   $ 	0:0:0.960��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   �� 5   .   $ 	0:0:1.200��6C   $	 0.0Q�6W   $ 0.42,0 0.58,1��6c   5  +   5  '   5  #   5     ._�5     � $
 Ring��6   #��z��5     $y�	Collapsed=�5      5	     �� 5
  "   $��7* �63   �� 5  "   $��2* �63   �� 5  "   $��7* �63    5     �� 5  "   $��* �60   �� 5  "   $��7* �60   .+�5     �� $��0��6%   $��1��62   $ 0.5,4.0&�6B   z�5  "   �� 5  &   $ 0Q�66   ._�5  "   A� $ ProgressElement1��6*   #��z��6E   $ 0.5,0.5&�6i   z�5  &   �� 5  *   5  #   5     �� 5     $��0��6%   $��1��62   $ 0.5,4.0&�6B   z�5   "   �� 5!  &   $ 45Q�66   ._�5$  "   A� $ ProgressElement2��6*   #��z��6E   $ 0.5,0.5&�6i   z�5%  &   �� 5&  *   5(  #   5)     �� 5+     $��0��6%   $��1��62   $ 0.5,4.0&�6B   z�5,  "   �� 5-  &   $ 90Q�66   ._�50  "   A� $ ProgressElement3��6*   #��z��6E   $ 0.5,0.5&�6i   z�51  &   �� 52  *   54  #   55     �� 57     $��0��6%   $��1��62   $ 0.5,4.0&�6B   z�58  "   �� 59  &   $	 135Q�66   ._�5<  "   A� $ ProgressElement4��6*   #��z��6E   $ 0.5,0.5&�6i   z�5=  &   �� 5>  *   5@  #   5A     �� 5C     $��0��6%   $��1��62   $ 0.5,4.0&�6B   z�5D  "   �� 5E  &   $	 180Q�66   ._�5H  "   A� $ ProgressElement5��6*   #��z��6E   $ 0.5,0.5&�6i   z�5I  &   �� 5J  *   5L  #   5M     �� 5O     $��0��6%   $��1��62   $ 0.5,4.0&�6B   z�5P  "   �� 5Q  &   $	 225Q�66   ._�5T  "   A� $ ProgressElement6��6*   #��z��6E   $ 0.5,0.5&�6i   z�5U  &   �� 5V  *   5X  #   5Y     �� 5[     $��0��6%   $��1��62   $ 0.5,4.0&�6B   z�5\  "   �� 5]  &   $	 270Q�66   ._�5`  "   A� $ ProgressElement7��6*   #��z��6E   $ 0.5,0.5&�6i   z�5a  &   �� 5b  *   5d  #   5e     �� 5g     $��0��6%   $��1��62   $ 0.5,4.0&�6B   z�5h  "   �� 5i  &   $	 315Q�66   ._�5l  "   A� $ ProgressElement8��6*   #��z��6E   $ 0.5,0.5&�6i   z�5m  &   �� 5n  *   5p  #   5q     5r     5s     5t     5v     5w     5y     