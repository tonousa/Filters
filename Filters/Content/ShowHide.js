<script src="http://wss.parks.nycnet/jQuery%20Libraries%202/jquery-1.9.1.min.js"></script>
<script type="text/javascript" >
	$(document).ready(function() {
	    CheckboxColumn = 'Show Last Name';
	    ColumnsToShowHide = ['Last Name', 'First Name'];
	    BindForCheckboxForColumn(CheckboxColumn, ColumnsToShowHide);
	    CheckValueAndShowHide(CheckboxColumn, ColumnsToShowHide);

	    CheckboxColumn2 = "Show Company";
	    ColumnsToShowHide2 = ['Company', 'Job Title'];
	    BindForCheckboxForColumn(CheckboxColumn2, ColumnsToShowHide2);
	    CheckValueAndShowHide(CheckboxColumn2, ColumnsToShowHide2);

	});
	
	
// FUNCTIONS
function YesNoColumnValue(columnName)
{
    //alert("function YesNoColumnValue called");
    result  = $("input[type='checkbox'][title='" + columnName + "']").is(':checked');
    return result;
}
	
function ShowRowForColumn(columnNames, show)
{
    for (index = 0; index < columnNames.length; index++) {

        var $element = $("nobr").filter(function() {
            return $(this).text() === columnNames[index];
        });
        show ? $element.closest('tr').show() : $element.closest('tr').hide();

    }
}
	
function BindForCheckboxForColumn(ColumnToCheck, ColumnsToShowHide)
{
    $checkboxElement = 
    $("input[type='checkbox'][title='" + ColumnToCheck + "']");
    //$checkboxElement.hide();
    $checkboxElement.click( function() {
        //alert("checkbox clicked");
        CheckValueAndShowHide(ColumnToCheck, ColumnsToShowHide);
});
    //alert("bind called");
}
	
function CheckValueAndShowHide(ColumnToCheck, ColumnsToShowHide)
{
    if (YesNoColumnValue(ColumnToCheck))
    {
        //alert("its checked");
        ShowRowForColumn(ColumnsToShowHide, true);
    }
    else
    {
        //alert("its not checked");
        ShowRowForColumn(ColumnsToShowHide, false);
    }
}
</script>