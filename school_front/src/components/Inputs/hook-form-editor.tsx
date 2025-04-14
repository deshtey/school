import { useController, Control } from "react-hook-form";
import RichTextEditor from "../RichTextEditor/RichTextEditor";

// Create a form-connected version of your editor
interface FormRichTextEditorProps {
  name: string;
  control: Control<any>;
  defaultValue?: string;
  label?: string;
  placeholder?: string
}

export const FormRichTextEditor = ({
  name,
  control,
  defaultValue = "",
  label, 
  placeholder
}: FormRichTextEditorProps) => {
  const {
    field: { onChange, value },
    fieldState: { error }
  } = useController({
    name,
    control,
    defaultValue
  });

  return (
    <div className="space-y-2">
      {label && <label className="text-sm font-medium dark:text-light">{label}</label>}
      <RichTextEditor content={value} onChange={onChange} placeholder={placeholder} />
      {error && <p className="text-sm text-red-500">{error.message}</p>}
    </div>
  );
};