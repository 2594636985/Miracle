   M S B A M L   `   `   `  ����R  NMiracle.Desktop.Toolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Miracle.Desktop.Toolkit.Windows.Controls(Miracle.Desktop.Toolkit.Windows.Controls  5      g8clr-namespace:Miracle.Desktop.Toolkit.Windows.Converters*Miracle.Desktop.Toolkit.Windows.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   BlackBackground  �� ColorF    @Miracle.Desktop.Toolkit.Windows.Converters.DrawerOffsetConverter  DrawerOffsetConverter5   /Miracle.Desktop.Toolkit.Windows.Controls.Navbar �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   From	   To	   
Storyboard
 �� 
TargetName �� TargetProperty �� Value �� KeyTime9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� Value O� KeyTime   EasingFunction-  'System.Windows.Media.Animation.SineEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode R� Value R� KeyTime   States   System.Windows.VisualState   
Storyboard	 W� To g� Duration<	  6System.Windows.Media.Animation.EasingThicknessKeyFrame p� Value p� KeyTime 	  EasingFunction W� From t� EasingFunction	 t� To �Name ��Name  J� Opacity! �� ContentStringFormat" �� ContentStringFormat# J� IsHitTestVisible$   LeftDrawerZIndex% K� ZIndex& �� RelativeSource' �� Path( �� 	Converter"
  System.Windows.Controls.Dock) 
  Left* �� ConverterParameter+ J� 	CacheMode&   System.Windows.Media.BitmapCache,   EnableClearType-   SnapsToDevicePixels.   LeftDrawerBackground/   LeftDrawerContent 0   LeftDrawerContentTemplate$1   LeftDrawerContentStringFormat2   RightDrawerZIndex3 
  Right4   RightDrawerBackground5   RightDrawerContent!6   RightDrawerContentTemplate%7   RightDrawerContentStringFormat�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      @mdtwc6clr-namespace:Miracle.Desktop.Toolkit.Windows.Controls  5      HpoAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/options  5      G
converters8clr-namespace:Miracle.Desktop.Toolkit.Windows.Converters  5      %�  &	        &	 %     '  8     7   7   7  7  �� 5      $  Transparent��6.      5      6'   �� 5
      "  6   .�5   
   ��  � }� . 6)   �� 5   
    �@ LeftDrawerBackground �#6b738461   �� 5   
    �@ RightDrawerBackground �#6b738462   �� 5   
    � �� .  6&   �� 5   
    � �� 5      �� 5      "  6"   .R�5      �� #��z��6   #��z��6Q    5        5      
AllDrawers�� 5   "     5   &   $ 	AllClosed��67   $ AnyOpen��6H   .	 5   *   �� .��5   .   �� $
 PART_ContentCover��6M   $ IsHitTestVisible�6w   .p�5   2   s�  . $ 0��6W   5   /   �� 5   .   $
 ContentPresenter��6M   $ 	IsEnabled�6v   .p�5   2   s�  .  $ 0��6X   5   /   U� 5   .   $
 PART_ContentCover��6L   $ Opacity�6v   .\�5   2     $ 0Q�6G   $ 0��6Q     5    2   $	 .56Q�6G   $ 0:0:0.3��6S    5!   6     5"   :   $ EaseOut=�6C   5$   3   5%   /   T� 5&   .   $
 PART_ContentCover��6L   $ 
Background�5'   P   ..�5(   2   i� 8   $ 0��6r   5)   /   5*   +   5+   '     5,   &   $ AnyOpen��67   $ 	AllClosed��6F   .	 5-   *   �� .��5.   .   U� $
 PART_ContentCover��6L   $ Opacity�6v   .\�5/   2     $
 0.56Q�6G   $ 0��6T     50   2   $ 0Q�6G   $ 0:0:0.3��6Q    51   6     52   :   $ 	EaseInOut=�6C   54   3   55   /   56   +   57   '   . 59   "     AnyOpen��. 5:   &   �� .��5;   *   W� $
 PART_ContentCover��6:   $ Opacity�6d   $	 .56X�5<   >   $ 0D�6G   �� 5=   *   $
 PART_ContentCover��6I   $ IsHitTestVisible�6s   .p�5>   .   s�  . $ 0��6S   5?   +   �� 5@   *   $
 ContentPresenter��6I   $ 	IsEnabled�6r   .p�5A   .   s�  .  $ 0��6T   5B   +   T� 5C   *   $
 PART_ContentCover��6H   $ 
Background�5D   L   ..�5E   .   i� 8  $ 0��6n   5F   +   5G   '   5H   #     5I   "   	AllClosed��. 5J   &   �� .��5K   *   W� $
 PART_ContentCover��6:   $ Opacity�6d   $ 0X�5L   >   �� 5M   *   $
 PART_ContentCover��6I   $ IsHitTestVisible�6s   .p�5N   .   s�  .  6F   5O   +   5P   '   5Q   #   5R        5S      
LeftDrawer�� 5T   "     5U   &   $ LeftDrawerClosed��67   $ LeftDrawerOpen��6O   .	 5V   *   �� .��5W   .   r� $ Margin�6O   $
 PART_LeftDrawer��6r   .	�5X   2   	  $ 0q�6J   $ 0:0:0.4��6T    5Y   6     5Z   :   $ EaseOut=�6C   5\   3   5]   /   W� 5^   .   $
 LeftDrawerShadow��6>   $ Opacity�6g   $ 0X�6�   $ 1X�6�   $ 0:0:0.04D�6�   5_   +   5`   '     5a   &   $ LeftDrawerOpen��67   $ LeftDrawerClosed��6M   .	 5b   *   �� .��5c   .   t� $ Margin�6A   $
 PART_LeftDrawer��6d   $ 0:0:0.4D�6�    5d   2     5e   6   $ EaseOut=�6?   5g   /   5h   +   5i   '   . 5k   "     LeftDrawerOpen��. 5l   &   �� .��5m   *   t� $ Margin�6=   $
 PART_LeftDrawer��6`   $ 0X�6�   $ 0D�6�   5n   '   5o   #     5p   "   LeftDrawerClosed��. 5q   &   �� .��5r   *   t� $ Margin�6=   $
 PART_LeftDrawer��6`   $ 0D�6�   5s   '   5t   #   5u        5v      RightDrawer�� 5w   "     5x   &   $ RightDrawerClosed��67   $ RightDrawerOpen��6P   .	 5y   *   �� .��5z   .   r� $ Margin�6O   $
 PART_RightDrawer��6r   .	�5{   2   	  $ 0q�6J   $ 0:0:0.4��6T    5|   6     5}   :   $ EaseOut=�6C   5   3   5�   /   5�   +   5�   '     5�   &   $ RightDrawerOpen��67   $ RightDrawerClosed��6N   .	 5�   *   �� .��5�   .   t� $ Margin�6A   $
 PART_RightDrawer��6d   $ 0:0:0.4D�6�    5�   2     5�   6   $ EaseOut=�6?   5�   /   5�   +   5�   '   . 5�   "     RightDrawerOpen��. 5�   &   �� .��5�   *   t� $ Margin�6=   $
 PART_RightDrawer��6`   $ 0 0 0 0X�6�   $ 0D�6�   5�   '   5�   #     5�   "   RightDrawerClosed��. 5�   &   �� .��5�   *   t� $ Margin�6=   $
 PART_RightDrawer��6`   $ 0D�6�   5�   '   5�   #   5�      ._�5�      � $ RootGrid��6   .+�5�      �� .u�5�   "   �� $ ContentPresenter��5�   )   $  1Q�6C   #��z��5�   )   #��z��6M   #" z! 6�   5�      � 5�      $ PART_ContentCover��6#   $  0Q�6T   # .  |�.  ��6>   Z� 6y   � 5�      .+�5�   "   � $ PART_LeftDrawer��5�   '   $
��Left=�5�   '   $��Stretch=�6B   #% z$ 5�   '   ��5�   '   �� & �� *Self+$' ActualWidth�8(  #* Z) .+�5�   &   �� + 5�   *     5�   .   , . - . 6Q   .u�5�   *   �� $  1Q�5�   1   #��z. 5�   1   5�   +   5�   '   �� 5�   &   #��z/ 67   #��z0 6e   #" z1 6�   5�   #   � 5�   "   $ PART_RightDrawer��5�   '   $��Stretch=�5�   '   $��Right=�6C   #% z2 5�   '   ��5�   '   �� & �� *Self+$' ActualWidth�8(  #* Z3 .+�5�   &   �� + 5�   *     5�   .   , . - . 6Q   .u�5�   *   �� $  1Q�5�   1   #��z4 5�   1   5�   +   5�   '   �� 5�   &   #��z5 67   #��z6 6f   #" z7 6�   5�   #   5�      5�      5�      5�      5�      5�      5�      