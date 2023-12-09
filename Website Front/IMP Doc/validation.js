function validate(controlId,errorControlId,errorMsg)
{
    var refToControlId = document.getElementById(controlId);
    var refToErrorControlId = document.getElementById(errorControlId);
    if(refToControlId.value.trim() == "")
    {
        refToErrorControlId.innerText = errorMsg;
        
    }
    else
    {
        refToErrorControlId.innerText ="";
    }
}