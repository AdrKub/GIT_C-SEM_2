   M S B A M L   `   `   `  ����K  GBook_MVVM_Step_6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Book_MVVM_Step_6Book_MVVM_Step_6  5   	   G(clr-namespace:Book_MVVM_Step_6.ViewModelBook_MVVM_Step_6.ViewModel  5   	   !    Book_MVVM_Step_6.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Book_MVVM_Step_6     5   	   Clocalviewmodel(clr-namespace:Book_MVVM_Step_6.ViewModel     5   	     � Title$  
MainWindow��5	   	   $��491.915��6   $��772.264��6-    � DataContext 5
      7   1Book_MVVM_Step_6.ViewModel.BookInventoryViewModel  5   
   .��5      � .+�5   
   �� $(��"MVVM Schritt 6 - Bücherverwaltung��6   $
��Left=�6<   $��	10,40,0,0q�6W   $	��Top=�6j   $	��409��6�   $
��Bold"�6�   �� 5   
   $��Title:��6   $
��Left=�6!   $��	66,77,0,0q�6<   $	��Top=�6O   �� 5   
   $��Author:��6   $
��Left=�6"   $��
51,108,0,0q�6=   $	��Top=�6Q   �� 5   
   $��Preis:��6   $
��Left=�6!   $��
63,139,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $��LblTitel��5   _   $
��Left=�6o   $��
141,77,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 1.676,-0.119&�6�   $	��297��6�   $��26��6�   ��6   ��  �� ElementName$ BookInventoryListView�� �� Path$ SelectedItem.Title�6�   �� 5   
   -   5        $��	LblAuthor��5   `   $
��Left=�6q   $��141,108,0,0q�6�   $	��Top=�6�   $ 1.676,-0.119&�6�   $	��297��6�   $��26��6�   ��6   �� $ BookInventoryListView��$ SelectedItem.Author�6�   �� 5   
   -   5        $��LblPreis��5   `   $
��Left=�6p   $��141,139,0,0q�6�   $	��Top=�6�   $ 1.676,-0.119&�6�   $	��201��6�   $��26��6�   ��6   �� $ BookInventoryListView��$ SelectedItem.Price�6�   �� 5   
   -   5        $��BtnSetTitle��5   (   $��Titel setzen��6   $
��Left=�6;   $��
39,196,0,0q�6V   $	��Top=�6j   $��98��6�   ��6�   �� *UpdateAllTitles+�� 5   
   -   5        $��BtnSetAuthor��5   )   $��Author setzen��6   $
��Left=�6=   $��
39,223,0,0q�6X   $	��Top=�6l   $��98��6�   ��6�   �� *UpdateAllAuthors+o� 5   
   $
��Left=�6   $��22��6*   $	��Top=�66   $	��137��6N   .@�5      m� $
��Edit��6   .@�5      m� $��Titel setzen��6    m� Command 61   �� *UpdateTitle+5      m� 5      $
��Test��6   .@�5      	� 5      5!      �� 5"   
   -   5        $��BookInventoryListView��5"      $
��Left=�60   $	��374��6K   $��
454,51,0,0q�6X   $	��Top=�6l   $	��285��6�   ��6�   �� *Books+��5#      �� 5$      .R�5%      �� .+�5&      �� $
��Bold"�6:   ��6    �� *Title+6:   �� 5'      ��6    �� *Author+5(      5)      5+      �� 5,   
   -   5        $��
BtnAddBook��5,      $��Hinzufügen��6#   $
��Left=�68   $��
39,288,0,0q�6S   $	��Top=�6g   $��98��6   ��6�   �� *	AddBook+�� 5-   
   -   5        $��BtnSetPrice��5-   (   $��Preis setzen��6   $
��Left=�6;   $��
39,250,0,0q�6V   $	��Top=�6j   $��98��6�   ��6�   �� *UpdateAllPrices+5.      5/      