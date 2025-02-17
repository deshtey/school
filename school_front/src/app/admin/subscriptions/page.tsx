import React from "react";

const Subscriptions: React.FC = () => {
  return (
    <div className='flex flex-col gap-8 items-start relative w-[1118px] h-[891px] bg-transparent'>
      <div className='flex flex-col gap-8 items-start relative w-[1118px] h-[472px] bg-transparent'>
        <div className='overflow-hidden rounded-2xl border border-[#d6b6d7] p-8 flex flex-col gap-4 items-start self-stretch relative w-full h-[472px] '>
          <div className='flex justify-between items-center relative w-[1060px] bg-transparent'>
            <div className='flex gap-4 items-center relative w-[542px] bg-transparent'>
              <div className='overflow-hidden rounded-[99px] border-2 border-[#9a4b9c] p-2 flex flex-col gap-2.5 items-center relative bg-[#9a4b9c]/15'>
                <svg width='24' height='24' viewBox='0 0 24 24' fill='none' xmlns='http://www.w3.org/2000/svg'>
                  <path
                    d='M3 13C3 15.3869 3.94821 17.6761 5.63604 19.364C7.32387 21.0518 9.61305 22 12 22C12 19.6131 11.0518 17.3239 9.36396 15.636C7.67613 13.9482 5.38695 13 3 13ZM12 22C14.3869 22 16.6761 21.0518 18.364 19.364C20.0518 17.6761 21 15.3869 21 13C18.6131 13 16.3239 13.9482 14.636 15.636C12.9482 17.3239 12 19.6131 12 22ZM18 3V8C18 9.5913 17.3679 11.1174 16.2426 12.2426C15.1174 13.3679 13.5913 14 12 14C10.4087 14 8.88258 13.3679 7.75736 12.2426C6.63214 11.1174 6 9.5913 6 8V3C6.74 3 7.47 3.12 8.16 3.39C8.71 3.62 9.2 3.96 9.61 4.39L12 2L14.39 4.39C14.8 3.96 15.29 3.62 15.84 3.39C16.53 3.12 17.26 3 18 3Z'
                    fill='#A892BF'
                  />
                </svg>
              </div>
              <h5 className='text-center font-semibold leading-6 text-xl text-[#353535]'>Subscription plan</h5>
            </div>
          </div>
          <header className='px-8 pt-8 pb-0 flex flex-col gap-6 items-start self-stretch relative w-full bg-transparent'>
            <div className='flex gap-8 items-center self-stretch relative w-full bg-transparent'>
              <div className='flex flex-col gap-2 items-center relative w-[345px] bg-transparent'>
                <div className='flex flex-col gap-5 items-center self-stretch relative w-full bg-transparent'>
                  <div className='rounded-[28px] border-[6px] border-[#f9f5ff] relative w-10 h-10 bg-[#f4ebff]'>
                    <svg width='21' height='20' viewBox='0 0 21 20' fill='none' xmlns='http://www.w3.org/2000/svg'>
                      <path
                        d='M11.3334 1.66602L3.91124 10.5726C3.62057 10.9214 3.47523 11.0958 3.47301 11.2431C3.47108 11.3711 3.52814 11.4929 3.62774 11.5734C3.74232 11.666 3.96934 11.666 4.42339 11.666H10.5L9.66669 18.3327L17.0888 9.42614C17.3795 9.07733 17.5248 8.90293 17.527 8.75563C17.529 8.62758 17.4719 8.50576 17.3723 8.42527C17.2577 8.33268 17.0307 8.33268 16.5767 8.33268H10.5L11.3334 1.66602Z'
                        stroke='#A892BF'
                        strokeWidth='1.66667'
                        strokeLinecap='round'
                        strokeLinejoin='round'
                      />
                    </svg>
                  </div>
                  <h5 className='text-center font-semibold leading-[30px] text-xl text-[#252525]'>Basic plan</h5>
                </div>
                <h1 className='tracking-[-0.096em] text-center font-semibold leading-[60px] text-5xl text-[#101828]'>
                  $10/mth
                </h1>
                <p className='text-center leading-6 text-base text-[#475467]'>Billed annually.</p>
              </div>
              <div className='flex flex-col gap-4 items-start relative w-[677px] bg-transparent'>
                <div className='flex gap-3 items-start self-stretch relative w-full bg-transparent'>
                  <svg width='24' height='24' viewBox='0 0 24 24' fill='none' xmlns='http://www.w3.org/2000/svg'>
                    <rect width='24' height='24' rx='12' fill='#F4EBFF' />
                    <path
                      fillRule='evenodd'
                      clipRule='evenodd'
                      d='M17.0964 7.38967L9.93638 14.2997L8.03638 12.2697C7.68638 11.9397 7.13638 11.9197 6.73638 12.1997C6.34638 12.4897 6.23638 12.9997 6.47638 13.4097L8.72638 17.0697C8.94638 17.4097 9.32638 17.6197 9.75638 17.6197C10.1664 17.6197 10.5564 17.4097 10.7764 17.0697C11.1364 16.5997 18.0064 8.40967 18.0064 8.40967C18.9064 7.48967 17.8164 6.67967 17.0964 7.37967V7.38967Z'
                      fill='#D8C7E4'
                    />
                  </svg>
                  <div className='flex flex-col gap-0 items-start flex-1 relative w-full bg-transparent'>
                    <p className='leading-6 text-base text-[#475467]'>Access to all basic features</p>
                  </div>
                </div>
                <div className='flex gap-3 items-start self-stretch relative w-full bg-transparent'>
                  <svg width='24' height='24' viewBox='0 0 24 24' fill='none' xmlns='http://www.w3.org/2000/svg'>
                    <rect width='24' height='24' rx='12' fill='#F4EBFF' />
                    <path
                      fillRule='evenodd'
                      clipRule='evenodd'
                      d='M17.0964 7.38967L9.93638 14.2997L8.03638 12.2697C7.68638 11.9397 7.13638 11.9197 6.73638 12.1997C6.34638 12.4897 6.23638 12.9997 6.47638 13.4097L8.72638 17.0697C8.94638 17.4097 9.32638 17.6197 9.75638 17.6197C10.1664 17.6197 10.5564 17.4097 10.7764 17.0697C11.1364 16.5997 18.0064 8.40967 18.0064 8.40967C18.9064 7.48967 17.8164 6.67967 17.0964 7.37967V7.38967Z'
                      fill='#D8C7E4'
                    />
                  </svg>
                  <div className='flex flex-col gap-0 items-start flex-1 relative w-full bg-transparent'>
                    <p className='leading-6 text-base text-[#475467]'>Basic reporting and analytics</p>
                  </div>
                </div>
                <div className='flex gap-3 items-start self-stretch relative w-full bg-transparent'>
                  <svg width='24' height='24' viewBox='0 0 24 24' fill='none' xmlns='http://www.w3.org/2000/svg'>
                    <rect width='24' height='24' rx='12' fill='#F4EBFF' />
                    <path
                      fillRule='evenodd'
                      clipRule='evenodd'
                      d='M17.0964 7.38967L9.93638 14.2997L8.03638 12.2697C7.68638 11.9397 7.13638 11.9197 6.73638 12.1997C6.34638 12.4897 6.23638 12.9997 6.47638 13.4097L8.72638 17.0697C8.94638 17.4097 9.32638 17.6197 9.75638 17.6197C10.1664 17.6197 10.5564 17.4097 10.7764 17.0697C11.1364 16.5997 18.0064 8.40967 18.0064 8.40967C18.9064 7.48967 17.8164 6.67967 17.0964 7.37967V7.38967Z'
                      fill='#D8C7E4'
                    />
                  </svg>
                  <div className='flex flex-col gap-0 items-start flex-1 relative w-full bg-transparent'>
                    <p className='leading-6 text-base text-[#475467]'>Up to 10 individual users</p>
                  </div>
                </div>
                <div className='flex gap-3 items-start self-stretch relative w-full bg-transparent'>
                  <svg width='24' height='24' viewBox='0 0 24 24' fill='none' xmlns='http://www.w3.org/2000/svg'>
                    <rect width='24' height='24' rx='12' fill='#F4EBFF' />
                    <path
                      fillRule='evenodd'
                      clipRule='evenodd'
                      d='M17.0964 7.38967L9.93638 14.2997L8.03638 12.2697C7.68638 11.9397 7.13638 11.9197 6.73638 12.1997C6.34638 12.4897 6.23638 12.9997 6.47638 13.4097L8.72638 17.0697C8.94638 17.4097 9.32638 17.6197 9.75638 17.6197C10.1664 17.6197 10.5564 17.4097 10.7764 17.0697C11.1364 16.5997 18.0064 8.40967 18.0064 8.40967C18.9064 7.48967 17.8164 6.67967 17.0964 7.37967V7.38967Z'
                      fill='#D8C7E4'
                    />
                  </svg>
                  <div className='flex flex-col gap-0 items-start flex-1 relative w-full bg-transparent'>
                    <p className='leading-6 text-base text-[#475467]'>20GB individual data each user</p>
                  </div>
                </div>
                <div className='flex gap-3 items-start self-stretch relative w-full bg-transparent'>
                  <svg width='24' height='24' viewBox='0 0 24 24' fill='none' xmlns='http://www.w3.org/2000/svg'>
                    <rect width='24' height='24' rx='12' fill='#F4EBFF' />
                    <path
                      fillRule='evenodd'
                      clipRule='evenodd'
                      d='M17.0964 7.38967L9.93638 14.2997L8.03638 12.2697C7.68638 11.9397 7.13638 11.9197 6.73638 12.1997C6.34638 12.4897 6.23638 12.9997 6.47638 13.4097L8.72638 17.0697C8.94638 17.4097 9.32638 17.6197 9.75638 17.6197C10.1664 17.6197 10.5564 17.4097 10.7764 17.0697C11.1364 16.5997 18.0064 8.40967 18.0064 8.40967C18.9064 7.48967 17.8164 6.67967 17.0964 7.37967V7.38967Z'
                      fill='#D8C7E4'
                    />
                  </svg>
                  <div className='flex flex-col gap-0 items-start flex-1 relative w-full bg-transparent'>
                    <p className='leading-6 text-base text-[#475467]'>Basic chat and email support</p>
                  </div>
                </div>
                <div className='flex gap-3 items-start self-stretch relative w-full bg-transparent'>
                  <div className='flex flex-col gap-0 items-start flex-1 relative w-full bg-transparent'>
                    <p className='leading-6 text-base text-[#475467]'>Expires 10th August 2025</p>
                  </div>
                </div>
              </div>
            </div>
          </header>
          <footer className='p-8 flex flex-col gap-6 items-start self-stretch relative w-full bg-gray-50'>
            <button className='rounded-[32px] border border-[#d8c7e4] p-3 flex gap-0 justify-center items-center self-stretch relative w-full bg-[#a892bf]'>
              <div className='px-4 flex gap-0 justify-center items-center relative bg-transparent'>
                <p className='tracking-[0.5px] font-medium leading-6 text-base text-white'>Upgrade</p>
              </div>
            </button>
          </footer>
        </div>
        <div className='flex gap-2 items-start relative w-[335px] bg-transparent'>
          <div className='rounded-2xl border-[1.5px] border-[#dbd8f3] px-2.5 py-1 flex gap-0 justify-center items-center relative bg-[#dbd8f3]'>
            <small className='text-center font-medium leading-[18px] text-xs text-[#1e194f]'>Payment method</small>
          </div>
          <div className='rounded-2xl border-[1.5px] border-[#475467] pl-2.5 pr-1.5 py-1 flex gap-1 justify-center items-center relative bg-[#f8f7fd]'>
            <small className='text-center leading-[18px] text-xs text-[#252525]'>Billing history</small>
          </div>
          <div className='rounded-2xl border-[1.5px] border-[#475467] pl-2.5 pr-1.5 py-1 flex gap-1 justify-center items-center relative bg-[#f8f7fd]'>
            <small className='text-center leading-[18px] text-xs text-[#252525]'>Images</small>
          </div>
          <div className='rounded-2xl border-[1.5px] border-[#475467] pl-2.5 pr-1.5 py-1 flex gap-1 justify-center items-center relative bg-[#f8f7fd]'>
            <small className='text-center leading-[18px] text-xs text-[#252525]'>Videos</small>
          </div>
          <div className='rounded-2xl border-[1.5px] border-[#475467] pl-2.5 pr-1.5 py-1 flex gap-1 justify-center items-center relative bg-[#f8f7fd]'>
            <small className='text-center leading-[18px] text-xs text-[#252525]'>Audios</small>
          </div>
        </div>
      </div>
      <div className='flex flex-col gap-8 items-start relative w-[1118px] h-[387px] bg-transparent'>
        <div className='flex gap-2 items-start relative w-[335px] bg-transparent'>
          <div className='rounded-2xl border-[1.5px] border-[#dbd8f3] px-2.5 py-1 flex gap-0 justify-center items-center relative bg-[#dbd8f3]'>
            <small className='text-center font-medium leading-[18px] text-xs text-[#1e194f]'>Payment method</small>
          </div>
          <div className='rounded-2xl border-[1.5px] border-[#475467] pl-2.5 pr-1.5 py-1 flex gap-1 justify-center items-center relative bg-[#f8f7fd]'>
            <small className='text-center leading-[18px] text-xs text-[#252525]'>Billing history</small>
          </div>
          <div className='rounded-2xl border-[1.5px] border-[#475467] pl-2.5 pr-1.5 py-1 flex gap-1 justify-center items-center relative bg-[#f8f7fd]'>
            <small className='text-center leading-[18px] text-xs text-[#252525]'>Images</small>
          </div>
          <div className='rounded-2xl border-[1.5px] border-[#475467] pl-2.5 pr-1.5 py-1 flex gap-1 justify-center items-center relative bg-[#f8f7fd]'>
            <small className='text-center leading-[18px] text-xs text-[#252525]'>Videos</small>
          </div>
          <div className='rounded-2xl border-[1.5px] border-[#475467] pl-2.5 pr-1.5 py-1 flex gap-1 justify-center items-center relative bg-[#f8f7fd]'>
            <small className='text-center leading-[18px] text-xs text-[#252525]'>Audios</small>
          </div>
        </div>
        <div className='overflow-hidden rounded-2xl border border-[#d6b6d7] p-8 flex flex-col gap-4 items-start self-stretch relative w-full h-[329px] '>
          <div className='flex justify-between items-center relative w-[1060px] bg-transparent'>
            <div className='flex gap-4 items-center relative w-[542px] bg-transparent'>
              <h5 className='text-center font-semibold leading-6 text-xl text-[#353535]'>Subscription plan</h5>
            </div>
          </div>
          <div className='flex flex-col gap-6 items-start relative h-[295px] bg-transparent'>
            <div className='flex flex-col gap-2 justify-center items-start relative bg-transparent'>
              <p className='font-medium text-base text-[#1c1b1f]'>Manage your payment methods</p>
              <small className='text-sm text-[#8c8c8c]'>Add, update, or remove your payment methods</small>
            </div>
            <div className='flex flex-col gap-4 items-start relative bg-transparent'>
              <div className='flex justify-between items-center self-stretch relative w-full bg-transparent'>
                <div className='flex gap-2 justify-center items-center relative bg-transparent'>
                  <img
                    src='https://picsum.photos/id/70/60/46'
                    className="rounded-lg border border-[#eceef1] w-15 h-[46px] bg-[url('https://picsum.photos/id/87/60/46')] bg-no-repeat"
                  />
                  <small className='text-sm text-[#474554]'>Phone number ending in 82</small>
                </div>
                <div className='flex gap-4 justify-center items-center relative bg-transparent'>
                  <small className='font-semibold text-sm text-[#9a4b9c]'>Edit</small>
                  <small className='font-semibold text-sm text-[#e5352b]'>Remove</small>
                </div>
              </div>
              <div className='flex justify-between items-center self-stretch relative w-full h-[46px] bg-transparent'>
                <div className='flex gap-2 justify-center items-center self-stretch relative h-full bg-transparent'>
                  <div className='rounded-lg border border-[#eaefec] p-2.5 flex flex-col gap-2.5 justify-center items-center self-stretch relative w-[59px] h-full /[98%]'>
                    <svg width='49' height='16' viewBox='0 0 49 16' fill='none' xmlns='http://www.w3.org/2000/svg'>
                      <path
                        d='M31.7641 0C28.3559 0 25.3102 1.81736 25.3102 5.17509C25.3102 9.02581 30.712 9.29173 30.712 11.2262C30.712 12.0408 29.8046 12.7699 28.2549 12.7699C26.0556 12.7699 24.4119 11.7511 24.4119 11.7511L23.7085 15.1394C23.7085 15.1394 25.6021 16 28.1161 16C31.8424 16 34.7744 14.0934 34.7744 10.6782C34.7744 6.60932 29.3503 6.35126 29.3503 4.55575C29.3503 3.91763 30.0951 3.21852 31.6404 3.21852C33.3839 3.21852 34.8063 3.95947 34.8063 3.95947L35.4946 0.686919C35.4946 0.686919 33.9469 0 31.7641 0ZM0.582529 0.246985L0.5 0.740956C0.5 0.740956 1.93383 1.01092 3.22523 1.5495C4.88803 2.16696 5.00642 2.52651 5.28652 3.64303L8.33807 15.7453H12.4287L18.7307 0.246985H14.6494L10.6001 10.7843L8.94766 1.85239C8.79608 0.83017 8.0285 0.246985 7.08897 0.246985H0.582529ZM20.3718 0.246985L17.1702 15.7453H21.062L24.2524 0.246985H20.3718ZM42.0779 0.246985C41.1395 0.246985 40.6423 0.763933 40.2774 1.66715L34.5756 15.7453H38.6569L39.4465 13.3989H44.4187L44.8988 15.7453H48.5L45.3584 0.246985H42.0779ZM42.6087 4.43413L43.8185 10.2499H40.5775L42.6087 4.43413Z'
                        fill='#1434CB'
                      />
                    </svg>
                  </div>
                  <div className='flex flex-col gap-1 items-start relative bg-transparent'>
                    <small className='text-sm text-[#474554]'>Visa ending in 7382</small>
                    <small className='font-medium text-xs text-[#9a4b9c]'>Set as Primary</small>
                  </div>
                </div>
                <div className='flex gap-4 justify-center items-center relative bg-transparent'>
                  <small className='font-semibold text-sm text-[#9a4b9c]'>Edit</small>
                  <small className='font-semibold text-sm text-[#e5352b]'>Remove</small>
                </div>
              </div>
              <div className='flex gap-[365px] justify-center items-center relative bg-transparent'>
                <div className='flex gap-2 justify-center items-center relative bg-transparent'>
                  <svg width='24' height='24' viewBox='0 0 24 24' fill='none' xmlns='http://www.w3.org/2000/svg'>
                    <path d='M19 13H13V19H11V13H5V11H11V5H13V11H19V13Z' fill='#A892BF' />
                  </svg>
                  <small className='font-semibold text-sm text-[#a892bf]'>Add payment method</small>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};
export default Subscriptions;
