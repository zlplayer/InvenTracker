import { createPortal } from "react-dom"
import styles from "./DropdownMenu.module.sass"
import { useEffect } from "react"

interface DropdownMenuProps {
    isOpen: boolean
    onClose: () => void
    children: React.ReactNode
    menuPosition?: { top: number, right: number }
}

const DropdownMenu = ({ isOpen, onClose, children, menuPosition } : DropdownMenuProps) => {
  const rootElement = document.getElementById("root");

    useEffect(() => {
        if (!isOpen) return;
    
        const handleEsc = (e: KeyboardEvent) => {
          if (e.key === "Escape") onClose();
        };
        document.addEventListener("keydown", handleEsc);
    
        return () => {
          document.removeEventListener("keydown", handleEsc);
          document.body.style.overflow = "";
        };
      }, [isOpen, onClose]);
    
      if (!isOpen || !rootElement) return null;

    return createPortal(
    <div
      className={styles.overlayStyle}
      onClick={onClose} // klik gdziekolwiek poza menu zamyka
    >
      <div
        className={styles.contentStyle}
        style={{ position: "fixed", top: menuPosition?.top, right: menuPosition?.right }}
        onClick={(e) => e.stopPropagation()} // klik w środek nie zamyka
      >
        {children}
      </div>
    </div>,
    rootElement // musi istnieć w index.html
  );
}

export default DropdownMenu