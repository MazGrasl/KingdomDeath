import { ValidatorFn, Validators } from "@angular/forms";

export function requiredIfValidator(predicate: () => boolean): ValidatorFn {
    return (formControl => {
      if (!formControl.parent) {
        return null;
      }
      if (predicate()) {
        return Validators.required(formControl); 
      }
      return null;
    })
}