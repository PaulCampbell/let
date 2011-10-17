$ ->
   $('.add-on :checkbox').click(function () {
        if ($(this).attr('checked')) 
            $(this).parents('.add-on').addClass('active');
        else 
            $(this).parents('.add-on').removeClass('active');
        

	class Common
		ToggleEditState: (showEditState, clickedLink) ->
			if showEditState
				clickedLink.parent('div').hide();
				clickedLink.parent('div').parent('li').find('.edit-state').show('fast');
		
			else 
				clickedLink.parent().parent('.edit-state').hide('fast');
				clickedLink.parent('div').parent('div').parent('li').find('.view-state').show();
		
	window.Common = new Common
	 