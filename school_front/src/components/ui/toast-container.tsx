import React from "react";
import { CheckCircle, XCircle, AlertCircle, X } from "lucide-react";
import { motion, AnimatePresence } from "framer-motion";
import { ToastType, useToast } from "./toast-content";

// Toast Component
const ToastMessage: React.FC<{
  id: string;
  message: string;
  type: ToastType;
  onClose: () => void;
}> = ({ id, message, type, onClose }) => {
  const icons = {
    success: <CheckCircle className="w-5 h-5 text-green-500" />,
    error: <XCircle className="w-5 h-5 text-red-500" />,
    warning: <AlertCircle className="w-5 h-5 text-yellow-500" />,
  };

  const backgrounds = {
    success: "bg-green-50 border-green-200",
    error: "bg-red-50 border-red-200",
    warning: "bg-yellow-50 border-yellow-200",
  };

  return (
    <motion.div
      key={id}
      initial={{ opacity: 0, y: -20 }}
      animate={{ opacity: 1, y: 0 }}
      exit={{ opacity: 0, y: -10 }}
      transition={{ duration: 0.3 }}
      className={`flex items-center justify-between p-4 mb-3 border rounded-lg shadow-sm ${backgrounds[type]}`}
    >
      <div className="flex items-center space-x-3">
        {icons[type]}
        <p className="text-sm font-medium text-gray-800">{message}</p>
      </div>
      <button
        onClick={onClose}
        className="p-1 rounded-full hover:bg-gray-200 transition-colors"
        type="button"
      >
        <X className="w-4 h-4 text-gray-500" />
      </button>
    </motion.div>
  );
};

// ToastContainer Component
const ToastContainer: React.FC = () => {
  const { toasts, removeToast } = useToast();
  
  return (
    <div className="fixed top-4 right-4 z-50 w-80">
      <AnimatePresence>
        {toasts.map((toast) => (
          <ToastMessage
            key={toast.id}
            {...toast}
            onClose={() => removeToast(toast.id)}
          />
        ))}
      </AnimatePresence>
    </div>
  );
};

export default ToastContainer;