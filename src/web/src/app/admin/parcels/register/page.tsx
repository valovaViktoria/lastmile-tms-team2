import { PackagePlus } from "lucide-react";
import {
  dashboardContentMaxClass,
  dashboardGutterXClass,
  dashboardPageVerticalClass,
} from "@/lib/navigation/dashboard-layout";
import { ParcelRegistrationForm } from "@/components/parcels/parcel-registration-form";

export default function ParcelRegisterPage() {
  return (
    <main
      className={`${dashboardGutterXClass} ${dashboardPageVerticalClass}`}
    >
      <div className={dashboardContentMaxClass}>
        <div className="mb-8 flex items-center gap-3">
          <div className="flex h-10 w-10 items-center justify-center rounded-xl bg-primary/10">
            <PackagePlus className="h-5 w-5 text-primary" />
          </div>
          <div>
            <h1 className="text-2xl font-bold">Register Parcel</h1>
            <p className="text-muted-foreground text-sm">
              Enter sender, recipient, and parcel details to register a new
              shipment.
            </p>
          </div>
        </div>

        <ParcelRegistrationForm />
      </div>
    </main>
  );
}
