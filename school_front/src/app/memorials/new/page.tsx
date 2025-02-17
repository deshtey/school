"use client";
import React from "react";
import IndexLayout from "@/app/IndexLayout";
import { useForm } from "react-hook-form";
import {
  StepConnector,
  stepConnectorClasses,
  StepIconProps,
  styled,
} from "@mui/material";
import { faCircleCheck } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import MemorialForm from "@/components/dashboard/memorialform";
interface IFormInput {
  firstname: string;
  lastname: string;
  dob: Date | null;
  dod: Date | null;
  biography: string;
  gender: string;
  privacy: boolean;
  email: string;
  slug: string;
  personalphrase: string;
}
const QontoConnector = styled(StepConnector)(({ theme }) => ({
  [`&.${stepConnectorClasses.alternativeLabel}`]: {
    top: 10,
    left: "calc(-50% + 16px)",
    right: "calc(50% + 16px)",
  },
  [`&.${stepConnectorClasses.active}`]: {
    [`& .${stepConnectorClasses.line}`]: {
      borderColor: "#784af4",
    },
  },
  [`&.${stepConnectorClasses.completed}`]: {
    [`& .${stepConnectorClasses.line}`]: {
      borderColor: "#784af4",
    },
  },
  [`& .${stepConnectorClasses.line}`]: {
    borderColor: "#eaeaf0",
    borderTopWidth: 3,
    borderRadius: 1,
    ...theme.applyStyles("dark", {
      borderColor: theme.palette.grey[800],
    }),
  },
}));
const QontoStepIconRoot = styled("div")<{ ownerState: { active?: boolean } }>(({ theme }) => ({
  color: "#eaeaf0",
  display: "flex",
  height: 22,
  alignItems: "center",
  "& .QontoStepIcon-completedIcon": {
    color: "#784af4",
    zIndex: 1,
    fontSize: 18,
  },
  "& .QontoStepIcon-circle": {
    width: 8,
    height: 8,
    borderRadius: "50%",
    backgroundColor: "currentColor",
  },
  ...theme.applyStyles("dark", {
    color: theme.palette.grey[700],
  }),
  variants: [
    {
      props: ({ ownerState }) => ownerState.active,
      style: {
        color: "#784af4",
      },
    },
  ],
}));
function QontoStepIcon(props: StepIconProps) {
  const { active, completed, className } = props;

  return (
    <QontoStepIconRoot ownerState={{ active }} className={className}>
      {completed ? (
        <FontAwesomeIcon icon={faCircleCheck} className='QontoStepIcon-completedIcon' />
      ) : (
        <div className='QontoStepIcon-circle' />
      )}
    </QontoStepIconRoot>
  );
}
const genderOptions = [
  { value: "male", label: "Male" },
  { value: "female", label: "Female" },
  { value: "other", label: "Other" },
];
const NewMemorial: React.FC = () => {
  const { control, register, handleSubmit } = useForm<IFormInput>({
    defaultValues: {
      firstname: "",
      lastname: "",
      dob: null,
      dod: null,
      biography: "",
      gender: "",
      privacy: true,
      personalphrase: "",
    },
  });

  return (
    <IndexLayout>
      <MemorialForm />
    </IndexLayout>
  );
};

export default NewMemorial;
