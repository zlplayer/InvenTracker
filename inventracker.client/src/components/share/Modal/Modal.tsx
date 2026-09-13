import { useEffect } from "react";
import { createPortal } from "react-dom";
import styles from "./Modal.module.sass";

interface ModalProps {
  isOpen: boolean;
  onClose: () => void;
  children: React.ReactNode;
}

function Modal({ isOpen, onClose, children } : ModalProps) {
  const rootElement = document.getElementById("root");

  useEffect(() => {
    if (!isOpen) return;

    const handleEsc = (e: KeyboardEvent) => {
      if (e.key === "Escape") onClose();
    };
    document.addEventListener("keydown", handleEsc);

    // blokada scrolla tła
    document.body.style.overflow = "hidden";

    return () => {
      document.removeEventListener("keydown", handleEsc);
      document.body.style.overflow = "";
    };
  }, [isOpen, onClose]);

  if (!isOpen || !rootElement) return null;

  return createPortal(
    <div
      className={styles.overlayStyle}
      onClick={onClose} // klik w tło zamyka
    >
      <div
        className={styles.contentStyle}
        onClick={(e) => e.stopPropagation()} // klik w środek nie zamyka
      >
        <button onClick={onClose} className={styles.closeBtnStyle}>×</button>
        {children}
      </div>
    </div>,
    rootElement // musi istnieć w index.html
  );
}

export default Modal;
