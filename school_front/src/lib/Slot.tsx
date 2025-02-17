import React from 'react';

interface SlotProps {
  children: React.ReactNode;
  [key: string]: any;
}

const Slot = React.forwardRef<HTMLElement, React.HTMLAttributes<HTMLElement>>(
    ({ children, ...props }, ref) => {
      if (!children) {
        return null;
      }
  
      const child = React.Children.only(children) as React.ReactElement;
      
      return React.cloneElement(child, {
        ...props,
        ...child.props,
        ref: mergeRefs([ref, (child as any).ref]),
      });
    }
  );
  
  // Helper function to merge refs
  function mergeRefs(refs: any[]) {
    return (value: any) => {
      refs.forEach(ref => {
        if (typeof ref === 'function') {
          ref(value);
        } else if (ref != null) {
          ref.current = value;
        }
      });
    };
  }

export default Slot;