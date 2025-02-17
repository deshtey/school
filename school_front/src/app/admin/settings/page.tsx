import React from "react";

const Settings: React.FC = () => {
    return (
 

<div
  className="flex flex-col gap-8 items-start relative w-[1118px] h-[710px] bg-transparent">
  <div
    className="overflow-hidden rounded-2xl border border-[#d6b6d7] p-8 flex flex-col gap-4 items-start self-stretch relative w-full h-[710px] ">
    <div
      className="flex flex-col gap-8 items-start relative w-[855px] bg-transparent">
      <div
        className="rounded-lg p-2 flex flex-col gap-4 items-start relative w-[839px] h-[120px] ">
        <small
          className="tracking-[0.1px] font-medium leading-5 text-sm text-[#1c1c1c]"
          >Two-step verification options</small
        ><small
          className="tracking-[0.014399999999999998em] text-center font-semibold leading-5 underline text-xs text-[#e5352b]"
          >CHANGE EMAIL</small
        >
      </div>
      <div
        className="flex flex-col gap-7 items-start relative w-[349px] bg-transparent">
        <div
          className="flex flex-col gap-2 items-start self-stretch relative w-full bg-transparent">
          <p
            className="tracking-[0.2px] font-medium leading-6 text-base text-[#1c1c1c]">
            Need help? Contact us
          </p>
          <small
            className="tracking-[0.2px] text-center leading-5 text-sm text-[#1c1c1c]"
            >We’d love to hear your thoughts on this platform</small
          ><button
            className="rounded-lg flex gap-2 justify-center items-center relative bg-transparent">
            <span
              className="tracking-[0.016800000000000002em] text-center font-semibold leading-5 underline text-sm text-[#a892bf]">
              CONTACT US
            </span>
          </button>
        </div>
        <div className="flex flex-col gap-4 items-start relative bg-transparent">
          <button
            className="rounded-lg flex gap-2 justify-center items-center relative bg-transparent">
            <span
              className="tracking-[0.016800000000000002em] text-center font-semibold leading-5 underline text-sm text-[#a892bf]">
              PRIVACY POLICY
            </span></button
          ><button
            className="rounded-lg flex gap-2 justify-center items-center relative bg-transparent">
            <span
              className="tracking-[0.016800000000000002em] text-center font-semibold leading-5 underline text-sm text-[#a892bf]">
              TERMS AND CONDITIONS
            </span>
          </button>
        </div>
      </div>
    </div>
  </div>
</div>
    )
};
export default Settings